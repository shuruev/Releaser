using System;

namespace Releaser.Core
{
	/// <summary>
	/// Handler for create project command.
	/// </summary>
	public class CreateProjectCommandHandler : ICommandHandler
	{
		/// <summary>
		/// Executes command.
		/// </summary>
		public void Execute(BaseCommand baseCommand)
		{
			// TODO: Try to rework this idea.
			if (!(baseCommand is CreateProjectCommand))
				throw new Exception();

			var command = baseCommand as CreateProjectCommand;
		}
	}
}