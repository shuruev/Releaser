using System;

namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for changing release comment.
	/// </summary>
	public class ChangeReleaseComment : BaseCommand
	{
		/// <summary>
		/// Gets or sets release ID.
		/// </summary>
		public string ReleaseId { get; set; }

		/// <summary>
		/// Gets or sets release comment.
		/// </summary>
		public string Comment { get; set; }
	}
}