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
	public class CreateConfigurationHandlerTests
	{
		[TestMethod]
		public void Execute_Should_Save_Entity_To_Store()
		{
			var store = new Mock<IEntityStore>();
			var handler = new CreateConfigurationHandler(store.Object);

			const string code = "code";
			const string name = "name";
			const string description = "description";

			var command = new CreateConfiguration();
			command.ConfigurationCode = code;
			command.ConfigurationName = name;
			command.ConfigurationDescription = description;

			var events = handler.Execute(command);

			store.Verify(s => s.Write(It.Is<Configuration>(
				u => u.Name == name
					 && u.Id == code
					 && u.Description == description)),
				Times.Once());

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is ConfigurationCreated);

			var @event = (ConfigurationCreated)events[0];

			Assert.AreEqual(code, @event.Configuration.Id);
			Assert.AreEqual(name, @event.Configuration.Name);
			Assert.AreEqual(description, @event.Configuration.Description);
		}
	}
}