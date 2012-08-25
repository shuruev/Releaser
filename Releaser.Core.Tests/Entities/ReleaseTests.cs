using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Releaser.Core.Entities;
using Releaser.Core.Events;

namespace Releaser.Core.Tests.Entities
{
	[TestClass]
	public class ReleaseTests
	{
		[TestMethod]
		public void Contructor_Should_Generate_ReleaseCreated_Event()
		{
			const string code = "code";
			const string versionCode = "version code";
			const string projectId = "project id";
			const string userId = "user id";
			const string comment = "comment";

			var release = new Release(
				code,
				versionCode,
				projectId,
				userId,
				comment);

			var events = release.GetChanges();

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is ReleaseCreated);

			var @event = (ReleaseCreated)events[0];

			Assert.AreEqual(code, @event.Release.Id);
			Assert.AreEqual(versionCode, @event.Release.VersionCode);
			Assert.AreEqual(projectId, @event.Release.ProjectId);
			Assert.AreEqual(userId, @event.Release.UserId);
			Assert.AreEqual(comment, @event.Release.Comment);
		}

		[TestMethod]
		public void ChangeComment_Should_Generate_ReleaseCommentChanged_Event()
		{
			const string id = "code";
			const string comment = "comment";

			var release = new Release();
			release.Id = id;
			release.ChangeComment(comment);

			var events = release.GetChanges();

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is ReleaseCommentChanged);

			var @event = (ReleaseCommentChanged)events[0];

			Assert.AreEqual(id, @event.ReleaseId);
			Assert.AreEqual(comment, @event.ReleaseComment);
		}
	}
}