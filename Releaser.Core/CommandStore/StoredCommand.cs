using System;

namespace Releaser.Core.CommandStore
{
	/// <summary>
	/// Entity for storing commands.
	/// </summary>
	public class StoredCommand
	{
		/// <summary>
		/// Gets or sets type of command.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets time when command was stored.
		/// </summary>
		public DateTime StoreTime { get; set; }

		/// <summary>
		/// Gets or sets Json presenatatin of command.
		/// </summary>
		public string Json { get; set; }
	}
}