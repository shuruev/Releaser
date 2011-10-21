namespace Releaser.Core
{
	/// <summary>
	/// Interface for command handlers.
	/// </summary>
	public interface ICommandHandler
	{
		/// <summary>
		/// Executes command.
		/// </summary>
		void Execute(BaseCommand command);
	}
}