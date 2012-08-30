using System.Collections.Generic;

namespace Releaser.Core.Commands
{
	/// <summary>
	/// Command for adding keywords.
	/// </summary>
	public class AddKeywords : BaseCommand
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public AddKeywords()
		{
			Keywords = new List<string>();
		}

		/// <summary>
		/// Gets or sets project ID.
		/// </summary>
		public string ProjectId { get; set; }

		/// <summary>
		/// Gets or sets list of keywords.
		/// </summary>
		public List<string> Keywords { get; set; }
	}
}