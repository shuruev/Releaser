using Releaser.Core.Entities;

namespace Releaser.Core.Events
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
		/// Gets or sets created user.
		/// </summary>
		public User User { get; set; }
	}
}