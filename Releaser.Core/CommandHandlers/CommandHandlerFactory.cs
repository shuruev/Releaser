using System;
using System.Collections.Generic;
using System.Linq;
using Releaser.Core.Commands;
using Releaser.Core.EntityStore;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Factory for getting handlers by command.
	/// </summary>
	public class CommandHandlerFactory
	{
		private readonly Dictionary<string, ICommandHandler> m_handlers = new Dictionary<string, ICommandHandler>();

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CommandHandlerFactory(IEntityStore store)
		{
			RegisterAll(store);
		}

		/// <summary>
		/// Registers all handlers from all assemblies.
		/// </summary>
		private void RegisterAll(IEntityStore store)
		{
			var commandType = typeof(BaseCommand);
			var commandTypes = AppDomain.CurrentDomain
				.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => commandType.IsAssignableFrom(p) && p != commandType)
				.ToList();

			var handlerType = typeof(ICommandHandler);
			var handlerTypes = AppDomain.CurrentDomain
				.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => handlerType.IsAssignableFrom(p) && !p.IsAbstract && p.BaseType != null)
				.ToDictionary(v => v.BaseType.GetGenericArguments()[0]);

			foreach (Type type in commandTypes)
			{
				var command = (BaseCommand)Activator.CreateInstance(type);
				m_handlers[command.Name] = (ICommandHandler)Activator.CreateInstance(
					handlerTypes[type],
					store);
			}
		}

		/// <summary>
		/// Handles command by handler from the factory.
		/// </summary>
		public ICommandHandler ResolveHandler<T>(T command) where T : BaseCommand
		{
			ICommandHandler handler;
			return m_handlers.TryGetValue(command.Name, out handler) ? handler : null;
		}
	}
}
