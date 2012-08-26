using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles create deployment command.
	/// </summary>
	public class CreateDeploymentHandler : BaseCommandHandler<CreateDeployment>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CreateDeploymentHandler(IEntityStore store)
			: base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(CreateDeployment command)
		{
			var deployment = new Deployment(
				command.ReleaseId,
				command.ConfigurationId,
				command.UserId);

			m_store.Write(deployment);

			return deployment.GetChanges();
		}
	}
}