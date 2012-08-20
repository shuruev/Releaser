namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for creating project.
	/// </summary>
	public class CreateProjectCommand : BaseCommand
	{
		/// <summary>
		/// Gets or sets project name.
		/// </summary>
		public string ProjectName { get; set; }

		/// <summary>
		/// Gets or sets project display name.
		/// </summary>
		public string ProjectDisplayName { get; set; }

		/// <summary>
		/// Gets or sets path to project version.
		/// </summary>
		public string ProjectPath { get; set; }
	}
}
