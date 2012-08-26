using System;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Represents user.
	/// </summary>
	public class User : AggregateRoot
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public User()
		{
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public User(
			string userCode,
			string userLogin,
			string userName)
		{
			Login = userLogin;
			Name = userName;

			Id = userCode;
			CreationDate = DateTime.UtcNow;

			Apply(new UserCreated(this));
		}

		/// <summary>
		/// Gets or sets user login.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Gets or sets user name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets creation date.
		/// </summary>
		public DateTime CreationDate { get; set; }
	}
}