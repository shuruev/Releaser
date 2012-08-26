using Microsoft.VisualStudio.TestTools.UnitTesting;
using Releaser.Core.Entities;
using Releaser.Core.Events;

namespace Releaser.Core.Tests.Entities
{
	[TestClass]
	public class ConfigurationTests
	{
		[TestMethod]
		public void Contructor_Should_Generate_ReleaseCreated_Event()
		{
			const string code = "code";
			const string name = "name";
			const string description = "description";

			var configuration = new Configuration(
				code,
				name,
				description);

			var events = configuration.GetChanges();

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is ConfigurationCreated);

			var @event = (ConfigurationCreated)events[0];

			Assert.AreEqual(code, @event.Configuration.Id);
			Assert.AreEqual(name, @event.Configuration.Name);
			Assert.AreEqual(description, @event.Configuration.Description);
		}
	}
}