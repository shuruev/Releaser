using System;
using Releaser.Core;
using Releaser.Core.Commands;
using Releaser.Core.Dto;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;

namespace Releaser.Engine
{
	public class CommandService : RestServiceBase<CommandDto>
	{
		private CommandHandler m_engine = new CommandHandler();

		public override object OnPost(CommandDto requestCommand)
		{
			BaseCommand command = requestCommand.Json.FromJson<BaseCommand>();
			m_engine.ExecuteCommand(command);

			Console.WriteLine("Command received.");
			Console.WriteLine("Json is {0}.", requestCommand.Json);
			Console.WriteLine();
			return null;
		}
	}
}