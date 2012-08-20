using System;
using System.Collections.Generic;
using Releaser.Core.Commands;

namespace Releaser.Core.CommandStore
{
	/// <summary>
	/// Interface for storing commands.
	/// </summary>
	public interface ICommandStore
	{
		/// <summary>
		/// Saves command to a store.
		/// </summary>
		void SaveCommand(BaseCommand command);

		/// <summary>
		/// Reads all commands.
		/// </summary>
		IEnumerable<BaseCommand> ReadAllCommands();
	}
}