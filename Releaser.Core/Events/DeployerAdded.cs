using System;

namespace Releaser.Core.Events
{
	/// <summary>
	/// Event which raises after adding deployer.
	/// </summary>
	public class DeployerAdded : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public DeployerAdded(string configurationId, string userId)
		{
			ConfigurationId = configurationId;
			UserId = userId;
		}

		/// <summary>
		/// Gets or sets configuration ID.
		/// </summary>
		public string ConfigurationId { get; set; }

		/// <summary>
		/// Gets or sets user ID.
		/// </summary>
		public string UserId { get; set; }
	}
}