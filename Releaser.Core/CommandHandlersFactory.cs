using System.Collections.Generic;
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
	}
}
