using System;
using Releaser.Core.Commands;
using Releaser.Core.Utils;

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
			: base("Command {0} is not supported.".F(command.Name))
		{
		}
	}
}
