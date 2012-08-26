namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for creating user.
	/// </summary>
	public class CreateUser : BaseCommand
	{
		/// <summary>
		/// Gets or sets user login.
		/// </summary>
		public string UserLogin { get; set; }

		/// <summary>
		/// Gets or sets user code.
		/// </summary>
		public string UserCode { get; set; }

		/// <summary>
		/// Gets or sets user name.
		/// </summary>
		public string UserName { get; set; }
	}
}