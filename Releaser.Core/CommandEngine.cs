using Releaser.Core.Commands;
using Releaser.Core.Handlers;
using Releaser.Core.Ioc;
using Releaser.Core.Results;

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
		public CommandEngine(IResolver resolver)
		{
			// TODO: Do it automatically
			m_handlersFactory = new CommandHandlersFactory(resolver);
			m_handlersFactory.Register<CreateProjectCommand, CreateProjectCommandHandler>();
		}

		/// <summary>
		/// Executes command.
		/// </summary>
		public BaseResult ExecuteCommand(BaseCommand command)
		{
			ICommandHandler handler = m_handlersFactory.Resolve(command.Name);
			return handler.Execute(command);
		}
	}
}
