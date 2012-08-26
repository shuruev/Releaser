namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for creating deployment.
	/// </summary>
	public class CreateDeployment : BaseCommand
	{
		/// <summary>
		/// Gets or sets deployment release ID.
		/// </summary>
		public string ReleaseId { get; set; }

		/// <summary>
		/// Gets or sets deployment configuration ID.
		/// </summary>
		public string ConfigurationId { get; set; }

		/// <summary>
		/// Gets or sets deployment user ID.
		/// </summary>
		public string UserId { get; set; }
	}
}