using System;
using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;
using Releaser.Core.Utils;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles change release comment command.
	/// </summary>
	public class ChangeReleaseCommentHandler : BaseCommandHandler<ChangeReleaseComment>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ChangeReleaseCommentHandler(IEntityStore store) : base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(ChangeReleaseComment command)
		{
			var release = m_store.Read<Release>(command.ReleaseId);
			if (release == null)
			{
				throw new InvalidOperationException(
					"Release with ID = '{0}' does not exist in store.".F(command.ReleaseId));
			}

			release.ChangeComment(command.Comment);

			m_store.Write(release);

			return release.GetChanges();
		}
	}
}