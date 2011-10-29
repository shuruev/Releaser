using Releaser.Core.Commands;
using Releaser.Core.Exceptions;
using Releaser.Core.MongoDb;
using Releaser.Core.Results;

namespace Releaser.Core.Handlers
{
	/// <summary>
	/// Base class for command handlers.
	/// </summary>
	public abstract class BaseCommandHandler<T, TResult>
		: ICommandHandler
		where T : class
		where TResult : BaseResult
	{
		protected readonly IMongoDb m_mongoDb;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		protected BaseCommandHandler(IMongoDb mongoDb)
		{
			m_mongoDb = mongoDb;
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		public BaseResult Execute(BaseCommand command)
		{
			if (!(command is T))
				throw new CommandNotSupportedException();

			return ExecuteInternal(command as T);
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected abstract TResult ExecuteInternal(T command);
	}
}
