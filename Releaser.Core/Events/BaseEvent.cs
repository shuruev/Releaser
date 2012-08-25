using System;
using Newtonsoft.Json;

namespace Releaser.Core.Events
{
	/// <summary>
	/// Base class for all events.
	/// </summary>
	public class BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public BaseEvent()
		{
			CreationTime = DateTime.UtcNow;
		}

		/// <summary>
		/// Gets command name.
		/// </summary>
		[JsonIgnore]
		public string Name
		{
			get { return GetType().FullName; }
		}

		/// <summary>
		/// Gets creation time of event.
		/// </summary>
		public DateTime CreationTime { get; private set; }
	}
}
