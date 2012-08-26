using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Releaser.Core.CommandHandlers;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.Tests.CommandHandlers
{
	[TestClass]
	public class CreateDeploymentHandlerTests
	{
		[TestMethod]
		public void Execute_Should_Save_Entity_To_Store()
		{
			var store = new Mock<IEntityStore>();
			var handler = new CreateDeploymentHandler(store.Object);

			const string releaseId = "release id";
			const string configurationId = "configuration id";
			const string userId = "user id";

			var command = new CreateDeployment();
			command.ReleaseId = releaseId;
			command.ConfigurationId = configurationId;
			command.UserId = userId;

			var events = handler.Execute(command);

			store.Verify(s => s.Write(It.Is<Deployment>(
				u => u.ReleaseId == releaseId
				     && u.ConfigurationId == configurationId
				     && u.UserId == userId)),
			             Times.Once());

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is DeploymentCreated);

			var @event = (DeploymentCreated)events[0];

			Assert.AreEqual(releaseId, @event.Deployment.ReleaseId);
			Assert.AreEqual(configurationId, @event.Deployment.ConfigurationId);
			Assert.AreEqual(userId, @event.Deployment.UserId);
		}
	}
}