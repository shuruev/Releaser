namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for adding releaser.
	/// </summary>
	public class AddReleaser : BaseCommand
	{
		/// <summary>
		/// Gets or sets project ID.
		/// </summary>
		public string ProjectId { get; set; }

		/// <summary>
		/// Gets or sets user ID.
		/// </summary>
		public string UserId { get; set; }
	}
}