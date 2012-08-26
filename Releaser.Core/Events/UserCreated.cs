using System;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Event which raises after user creation.
	/// </summary>
	public class UserCreated : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public UserCreated(User user)
		{
			User = user;
		}

		/// <summary>
		/// Gets created user,
		/// </summary>
		public User User { get; private set; }
	}
}