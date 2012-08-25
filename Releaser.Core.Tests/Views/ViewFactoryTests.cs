using Microsoft.VisualStudio.TestTools.UnitTesting;
using Releaser.Core.Entities;
using Releaser.Core.Events;
using Releaser.Core.Views;

namespace Releaser.Core.Tests.Views
{
	[TestClass]
	public class ViewFactoryTests
	{
		[TestMethod]
		public void Factory_Should_Correctly_Resolve_Affected_Views()
		{
			var factory = new ViewFactory();

			var handlers = factory.GetAffectedViews(new ProjectCreated(new Project()));

			Assert.AreEqual(1, handlers.Count);
			Assert.AreEqual(typeof(ProjectsView), handlers[0].GetType());
		}
	}
}
