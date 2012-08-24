using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Interface for command handlers.
	/// </summary>
	public interface ICommandHandler
	{
		/// <summary>
		/// Executes specified command.
		/// </summary>
		IEnumerable<BaseEvent> Execute(BaseCommand command);
	}
}
