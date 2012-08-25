
using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles create project command.
	/// </summary>
	public class CreateProjectHandler : BaseCommandHandler<CreateProject>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CreateProjectHandler(IEntityStore store) : base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(CreateProject command)
		{
			var project = new Project(
				command.ProjectName,
				command.ProjectPath,
				command.ProjectStorageType,
				command.ProjectType);

			m_store.Write(project);

			return project.GetChanges();
		}
	}
}
