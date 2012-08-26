using System;

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
			string userLogin,
			string userCode,
			string userName)
		{
			Login = userLogin;
			Code = userCode;
			Name = userName;

			Id = Guid.NewGuid().ToString();
			CreationDate = DateTime.UtcNow;

			Apply(new UserCreated(this));
		}

		/// <summary>
		/// Gets or sets user login.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Gets or sets user code.
		/// </summary>
		public string Code { get; set; }

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