using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles create release command.
	/// </summary>
	public class CreateReleaseHandler : BaseCommandHandler<CreateRelease>
	{
		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(CreateRelease command)
		{
			// TODO: !!!: Fill unique code.
			var code = string.Empty;
			var release = new Release(
				code,
				command.VersionCode,
				command.ProjectId,
				command.UserId,
				command.Comment
				);

			return release.GetChanges();
		}
	}
}