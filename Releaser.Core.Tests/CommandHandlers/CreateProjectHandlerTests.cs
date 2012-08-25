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
	public class CreateProjectHandlerTests
	{
		[TestMethod]
		public void Execute_Should_Save_Entity_To_Store()
		{
			var store = new Mock<IEntityStore>();
			var handler = new CreateProjectHandler(store.Object);

			const string projectName = "project name";
			const string path = "path";
			const string storageType = "storage type";
			const string projectType = "project type";

			var command = new CreateProject();
			command.ProjectName = projectName;
			command.ProjectPath = path;
			command.ProjectStorageType = storageType;
			command.ProjectType = projectType;

			var events = handler.Execute(command);

			store.Verify(s => s.Write(It.Is<Project>(
				p => p.Name == projectName
					&& p.Path == path
					&& p.ProjectType == projectType
					&& p.StorageType == storageType)),
				Times.Once());

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is ProjectCreated);

			var @event = (ProjectCreated)events[0];

			Assert.AreEqual(projectName, @event.Project.Name);
			Assert.AreEqual(path, @event.Project.Path);
			Assert.AreEqual(storageType, @event.Project.StorageType);
			Assert.AreEqual(projectType, @event.Project.ProjectType);
		}
	}
}
