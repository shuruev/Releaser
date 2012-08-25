using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.Events;
using Releaser.Core.Handlers;

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
		protected override IEnumerable<BaseEvent> ExecuteInternal(CreateProjectCommand command)
		{
			Project project = new Project(
				command.ProjectName,
				command.ProjectPath,
				command.ProjectStorageType,
				command.ProjectType);

			// What about saving the project to a store?

			return project.GetChanges();
		}
	}
}
