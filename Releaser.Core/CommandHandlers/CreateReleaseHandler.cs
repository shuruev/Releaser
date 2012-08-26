using System;
using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles create release command.
	/// </summary>
	public class CreateReleaseHandler : BaseCommandHandler<CreateRelease>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CreateReleaseHandler(IEntityStore store) : base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(CreateRelease command)
		{
			var code = GetCode();
			var release = new Release(
				code,
				command.VersionCode,
				command.ProjectId,
				command.UserId,
				command.Comment);

			m_store.Write(release);

			return release.GetChanges();
		}

		private string GetCode()
		{
			while (true)
			{
				var code = Guid.NewGuid().ToString("N").ToUpper().Substring(0, 4);
				var release = m_store.Read<Release>(code);
				if (release == null)
					return code;
			}
		}
	}
}