using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles add keywords command.
	/// </summary>
	public class AddKeywordHandler : BaseCommandHandler<AddKeywords>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public AddKeywordHandler(IEntityStore store)
			: base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(AddKeywords command)
		{
			var project = m_store.Read<Project>(command.ProjectId);

			project.AddKeywords(command.Keywords);

			m_store.Write(project);

			return project.GetChanges();
		}
	}
}