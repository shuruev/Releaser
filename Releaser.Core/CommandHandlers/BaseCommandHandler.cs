using System.Collections.Generic;
using Releaser.Core.CommandHandlers;
using Releaser.Core.Commands;
using Releaser.Core.Events;
using Releaser.Core.Exceptions;

namespace Releaser.Core.Handlers
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
		public IEnumerable<BaseEvent> Execute(BaseCommand command)
		{
			if (!(command is T))
				throw new CommandNotSupportedException(command);

			return ExecuteInternal(command as T);
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected abstract IEnumerable<BaseEvent> ExecuteInternal(T command);
	}
}
