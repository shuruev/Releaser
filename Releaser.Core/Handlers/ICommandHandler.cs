using Releaser.Core.Commands;
using Releaser.Core.Results;

namespace Releaser.Core.Handlers
{
	/// <summary>
	/// Interface for command handlers.
	/// </summary>
	public interface ICommandHandler
	{
		/// <summary>
		/// Executes specified command.
		/// </summary>
		BaseResult Execute(BaseCommand command);
	}
}
