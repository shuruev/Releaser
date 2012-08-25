using System;

namespace Releaser.Core.EventStore
{
	/// <summary>
	/// Entity for storing events.
	/// </summary>
	public class StoredCommand
	{
		/// <summary>
		/// Gets or sets type of event.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets Json presenatatin of event.
		/// </summary>
		public string Json { get; set; }
	}
}
