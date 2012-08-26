using Releaser.Core.Entities;

namespace Releaser.Core.Events
{
	/// <summary>
	/// Event which raises after deployment creation.
	/// </summary>
	public class DeploymentCreated : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public DeploymentCreated(Deployment deployment)
		{
			Deployment = deployment;
		}

		/// <summary>
		/// Gets created deployment.
		/// </summary>
		public Deployment Deployment { get; private set; }
	}
}