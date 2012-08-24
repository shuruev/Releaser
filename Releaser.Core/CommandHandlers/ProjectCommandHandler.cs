using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.CommandStore;
using Releaser.Core.Denormalizer;
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
			return new List<BaseEvent>();
		}
	}
}
