using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Releaser.Core.Commands;
using Releaser.Core.Handlers;

namespace Releaser.Core
{
	/// <summary>
	/// Factory for command handlers.
	/// </summary>
	public class CommandHandlersFactory
	{
		private readonly Dictionary<string, ICommandHandler> m_commandHandlers = new Dictionary<string, ICommandHandler>();

		/// <summary>
		/// Registers handler for command.
		/// </summary>
		public void Register<TCommand, THandler>()
			where TCommand : BaseCommand, new()
			where THandler : ICommandHandler, new()
		{
			var command = new TCommand();
			var handler = new THandler();

			m_commandHandlers[command.Name] = handler;
		}

		/// <summary>
		/// Returns handler for specified command.
		/// Returns null if command is not registered.
		/// </summary>
		public ICommandHandler Resolve(string commandName)
		{
			if (m_commandHandlers.ContainsKey(commandName))
				return m_commandHandlers[commandName];

			return null;
		}

		/// <summary>
		/// Registers all handlers from all assemblies.
		/// </summary>
		public void RegisterAll()
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
				BaseCommand command = (BaseCommand)Activator.CreateInstance(type);
				m_commandHandlers[command.Name] = (ICommandHandler)Activator.CreateInstance(handlerTypes[type]);
			}
		}
	}
}
