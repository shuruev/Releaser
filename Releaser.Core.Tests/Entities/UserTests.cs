using Microsoft.VisualStudio.TestTools.UnitTesting;
using Releaser.Core.Entities;
using Releaser.Core.Events;

namespace Releaser.Core.Tests.Entities
{
	[TestClass]
	public class UserTests
	{
		[TestMethod]
		public void Contructor_Should_Generate_ProjectCreated_Event()
		{
			const string userLogin = "user login";
			const string userCode = "user code";
			const string userName = "user name";

			var user = new User(userLogin, userCode, userName);

			var events = user.GetChanges();

			Assert.AreEqual(1, events.Count);
			Assert.IsTrue(events[0] is UserCreated);

			var @event = (UserCreated)events[0];

			Assert.AreEqual(userLogin, @event.User.Login);
			Assert.AreEqual(userCode, @event.User.Code);
			Assert.AreEqual(userName, @event.User.Name);
		}
	}
}