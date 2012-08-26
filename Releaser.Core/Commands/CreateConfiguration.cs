namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for creating configuration.
	/// </summary>
	public class CreateConfiguration : BaseCommand
	{
		/// <summary>
		/// Gets or sets conffiguration code.
		/// </summary>
		public string ConfigurationCode { get; set; }

		/// <summary>
		/// Gets or sets configuration name.
		/// </summary>
		public string ConfigurationName { get; set; }

		/// <summary>
		/// Gets or sets configuration description.
		/// </summary>
		public string ConfigurationDescription { get; set; }
	}
}