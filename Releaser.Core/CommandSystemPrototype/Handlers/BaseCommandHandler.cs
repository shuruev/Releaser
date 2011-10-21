namespace Releaser.Core
{
	/// <summary>
	/// Base class for command handlers.
	/// </summary>
	public abstract class BaseCommandHandler<T>
		: ICommandHandler
		where T : class
	{
		/// <summary>
		/// Executes specified command.
		/// </summary>
		public void Execute(BaseCommand command)
		{
			if (!(command is T))
				throw new CommandNotSupportedException();

			ExecuteInternal(command as T);
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected abstract void ExecuteInternal(T command);
	}
}