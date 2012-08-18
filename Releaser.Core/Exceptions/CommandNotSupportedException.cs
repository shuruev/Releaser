using System;
using Releaser.Core.Commands;

namespace Releaser.Core.Exceptions
{
	/// <summary>
	/// Exception occured when handler can't execute command.
	/// </summary>
	public class CommandNotSupportedException : ArgumentException
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CommandNotSupportedException(BaseCommand command)
			: base(string.Format("Command {0} is not supported.", command.Name))
		{
		}
	}
}
