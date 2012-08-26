using Microsoft.VisualStudio.TestTools.UnitTesting;
using Releaser.Core.Entities;
using Releaser.Core.Events;

namespace Releaser.Core.Tests.Entities
{
	[TestClass]
	public class ProjectTests
	{
		[TestMethod]
		public void Contructor_Should_Generate_ProjectCreated_Event()
		{
			const string projectName = "project name";
			const string path = "path";
			const string storageType = "storage type";
			const string projectType = "project type";

			var project = new Project(
				projectName,
				path,
				storageType,
				projectType);

			var events = project.GetChanges();

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is ProjectCreated);

			var @event = (ProjectCreated)events[0];

			Assert.AreEqual(projectName, @event.Project.Name);
			Assert.AreEqual(path, @event.Project.Path);
			Assert.AreEqual(storageType, @event.Project.StorageType);
			Assert.AreEqual(projectType, @event.Project.ProjectType);
		}

		[TestMethod]
		public void AddReleaser_Should_Generate_Event_Releaser_Added()
		{
			const string projectId = "project id";
			const string userId = "user id";

			var project = new Project();
			project.Id = projectId;
			project.AddReleaser(userId);

			var events = project.GetChanges();

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is ReleaserAdded);

			var @event = (ReleaserAdded)events[0];

			Assert.AreEqual(projectId, @event.ProjectId);
			Assert.AreEqual(userId, @event.UserId);
		}
	}
}
