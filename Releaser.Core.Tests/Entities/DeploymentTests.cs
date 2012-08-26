using Microsoft.VisualStudio.TestTools.UnitTesting;
using Releaser.Core.Entities;
using Releaser.Core.Events;

namespace Releaser.Core.Tests.Entities
{
	[TestClass]
	public class DeploymentTests
	{
		[TestMethod]
		public void Contructor_Should_Generate_ProjectCreated_Event()
		{
			const string releaseId = "release id";
			const string configurationId = "configuration id";
			const string userId = "user id";

			var deployment = new Deployment(releaseId, configurationId, userId);

			var events = deployment.GetChanges();

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is DeploymentCreated);

			var @event = (DeploymentCreated)events[0];

			Assert.AreEqual(releaseId, @event.Deployment.ReleaseId);
			Assert.AreEqual(configurationId, @event.Deployment.ConfigurationId);
			Assert.AreEqual(userId, @event.Deployment.UserId);
		}
	}
}