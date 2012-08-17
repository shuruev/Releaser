using Releaser.Core.Commands;
using Releaser.Core.Handlers;
using Releaser.Core.Ioc;

namespace Releaser.Core
{
	/// <summary>
	/// Engine for executing commands.
	/// </summary>
	public class CommandEngine
	{
		private readonly CommandHandlersFactory m_handlersFactory;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CommandEngine()
		{
			// TODO: Do it automatically
			m_handlersFactory = new CommandHandlersFactory();
			m_handlersFactory.RegisterAll();
			//m_handlersFactory.Register<CreateProjectCommand, CreateProjectCommandHandler>();
		}

		/// <summary>
		/// Executes command.
		/// </summary>
		public void ExecuteCommand(BaseCommand command)
		{
			ICommandHandler handler = m_handlersFactory.Resolve(command.Name);
			handler.Execute(command);
		}
	}
}
