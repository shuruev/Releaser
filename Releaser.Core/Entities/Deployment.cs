using System;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Represents deployment.
	/// </summary>
	public class Deployment : AggregateRoot
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Deployment()
		{
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Deployment(
			string releaseId,
			string configurationId,
			string userId)
		{
			ReleaseId = releaseId;
			ConfigurationId = configurationId;
			UserId = userId;

			Id = Guid.NewGuid().ToString();
			CreationDate = DateTime.UtcNow;

			Apply(new DeploymentCreated(this));
		}

		/// <summary>
		/// Gets or sets deployment release ID.
		/// </summary>
		public string ReleaseId { get; set; }

		/// <summary>
		/// Gets or sets deployment configuration ID.
		/// </summary>
		public string ConfigurationId { get; set; }

		/// <summary>
		/// Gets or sets deployment user ID.
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Gets or sets deployment creation date.
		/// </summary>
		protected DateTime CreationDate { get; set; }
	}
}