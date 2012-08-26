namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for adding deployer.
	/// </summary>
	public class AddDeployer : BaseCommand
	{
		/// <summary>
		/// Gets or sets configuration ID.
		/// </summary>
		public string ConfigurationId { get; set; }

		/// <summary>
		/// Gets or sets user ID.
		/// </summary>
		public string UserId { get; set; }
	}
}