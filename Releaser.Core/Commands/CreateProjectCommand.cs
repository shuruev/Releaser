using ProtoBuf;
using Releaser.Core.Entities;

namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for creating project.
	/// </summary>
	public class CreateProjectCommand : BaseCommand
	{
		/// <summary>
		/// Gets or sets project.
		/// </summary>
		public Project Project { get; set; }
	}
}
