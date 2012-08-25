using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Releaser.Core.CommandHandlers;
using Releaser.Core.Commands;
using Releaser.Core.EntityStore;

namespace Releaser.Core.Tests.CommandHandlers
{
	[TestClass]
	public class CommandHandlerFactoryTests
	{
		[TestMethod]
		public void Factory_Should_Correctly_Resolve_Handler()
		{
			var store = new Mock<IEntityStore>();
			var factory = new CommandHandlerFactory(store.Object);

			var handler = factory.ResolveHandler(new CreateProject());

			Assert.AreEqual(typeof(CreateProjectHandler), handler.GetType());
		}
	}
}
