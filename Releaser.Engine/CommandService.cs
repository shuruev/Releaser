using Releaser.Core.CommandHandlers;
using Releaser.Core.Commands;
using Releaser.Core.Dto;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;

namespace Releaser.Engine
{
	/// <summary>
	/// Service which processes commands requests.
	/// </summary>
	public class CommandService : RestServiceBase<CommandDto>
	{
		private readonly CommandHandlerFactory m_factory;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CommandService()
		{
			m_factory = Context.HandlerFactory;
		}

		/// <summary>
		/// Raises on POST request with command.
		/// </summary>
		public override object OnPost(CommandDto requestCommand)
		{
			BaseCommand command = requestCommand.Json.FromJson<BaseCommand>();
			m_factory.ExecuteCommand(command);
			return null;
		}
	}
}
