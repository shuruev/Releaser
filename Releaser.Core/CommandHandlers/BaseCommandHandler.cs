using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Events;
using Releaser.Core.Exceptions;

namespace Releaser.Core.CommandHandlers
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
		public List<BaseEvent> Execute(BaseCommand command)
		{
			if (!(command is T))
				throw new CommandNotSupportedException(command);

			return ExecuteInternal(command as T);
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected abstract List<BaseEvent> ExecuteInternal(T command);
	}
}
