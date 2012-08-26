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
	public class CreateUserHandlerTests
	{
		[TestMethod]
		public void Execute_Should_Save_Entity_To_Store()
		{
			var store = new Mock<IEntityStore>();
			var handler = new CreateUserHandler(store.Object);

			const string userLogin = "user login";
			const string userCode = "user code";
			const string userName = "user name";

			var command = new CreateUser();
			command.UserCode = userCode;
			command.UserLogin = userLogin;
			command.UserName = userName;

			var events = handler.Execute(command);

			store.Verify(s => s.Write(It.Is<User>(
				u => u.Name == userName
					 && u.Code == userCode
					 && u.Login == userLogin)),
				Times.Once());

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is UserCreated);

			var @event = (UserCreated)events[0];

			Assert.AreEqual(userLogin, @event.User.Login);
			Assert.AreEqual(userCode, @event.User.Code);
			Assert.AreEqual(userName, @event.User.Name);
		}
	}
}