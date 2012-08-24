using Releaser.Core.Commands;

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
		void Execute(BaseCommand command);
	}
}
