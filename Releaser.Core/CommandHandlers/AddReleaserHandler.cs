using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles add releaser command.
	/// </summary>
	public class AddReleaserHandler : BaseCommandHandler<AddReleaser>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public AddReleaserHandler(IEntityStore store)
			: base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(AddReleaser command)
		{
			var project = m_store.Read<Project>(command.ProjectId);

			project.AddReleaser(command.UserId);

			m_store.Write(project);

			return project.GetChanges();
		}}
}