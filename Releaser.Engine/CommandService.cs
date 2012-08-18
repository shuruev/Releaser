using System;
using Releaser.Core;
using Releaser.Core.Commands;
using Releaser.Core.CommandStore;
using Releaser.Core.Denormalizer;
using Releaser.Core.Dto;
using Releaser.Core.Views;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;

namespace Releaser.Engine
{
	/// <summary>
	/// Service which processes commands requests.
	/// </summary>
	public class CommandService : RestServiceBase<CommandDto>
	{
		private readonly CommandHandler m_handler;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CommandService()
		{
			m_handler = Context.Handler;
		}


		/// <summary>
		/// Raises on POST request with command.
		/// </summary>
		public override object OnPost(CommandDto requestCommand)
		{
			BaseCommand command = requestCommand.Json.FromJson<BaseCommand>();
			m_handler.ExecuteCommand(command);
			return null;
		}
	}
}
