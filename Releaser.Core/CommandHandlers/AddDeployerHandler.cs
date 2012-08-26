using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles add deployer command.
	/// </summary>
	public class AddDeployerHandler : BaseCommandHandler<AddDeployer>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public AddDeployerHandler(IEntityStore store)
			: base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(AddDeployer command)
		{
			var configuration = m_store.Read<Configuration>(command.ConfigurationId);
			configuration.AddDeployer(command.UserId);

			m_store.Write(configuration);

			return configuration.GetChanges();
		}
	}
}