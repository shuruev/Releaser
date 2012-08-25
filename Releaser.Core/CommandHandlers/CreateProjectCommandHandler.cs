using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles all commands with projects.
	/// </summary>
	public class CreateProjectCommandHandler : BaseCommandHandler<CreateProjectCommand>
	{
		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(CreateProjectCommand command)
		{
			var project = new Project(
				command.ProjectName,
				command.ProjectPath,
				command.ProjectStorageType,
				command.ProjectType);

			// What about saving the project to a store?
			return project.GetChanges();
		}
	}
}
