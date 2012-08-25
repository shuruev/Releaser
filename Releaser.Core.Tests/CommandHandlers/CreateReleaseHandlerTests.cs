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
	public class CreateReleaseHandlerTests
	{
		[TestMethod]
		public void Execute_Should_Save_Entity_To_Store()
		{
			var store = new Mock<IEntityStore>();
			var handler = new CreateReleaseHandler(store.Object);

			const string versionCode = "version code";
			const string projectId = "project id";
			const string userId = "user id";
			const string comment = "comment";

			var command = new CreateRelease();
			command.VersionCode = versionCode;
			command.ProjectId = projectId;
			command.UserId = userId;
			command.Comment = comment;

			var events = handler.Execute(command);

			store.Verify(s => s.Write(It.Is<Release>(
				r => r.VersionCode == versionCode
					&& r.ProjectId == projectId
					&& r.UserId == userId
					&& r.Comment == comment)),
				Times.Once());

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is ReleaseCreated);

			var @event = (ReleaseCreated)events[0];

			Assert.AreEqual(versionCode, @event.Release.VersionCode);
			Assert.AreEqual(projectId, @event.Release.ProjectId);
			Assert.AreEqual(userId, @event.Release.UserId);
			Assert.AreEqual(comment, @event.Release.Comment);
		}
	}
}