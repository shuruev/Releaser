using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles create configuration command.
	/// </summary>
	public class CreateConfigurationHandler : BaseCommandHandler<CreateConfiguration>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CreateConfigurationHandler(IEntityStore store)
			: base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(CreateConfiguration command)
		{
			var configuration = new Configuration(
				command.ConfigurationCode,
				command.ConfigurationName,
				command.ConfigurationDescription);

			m_store.Write(configuration);

			return configuration.GetChanges();
		}
	}
}