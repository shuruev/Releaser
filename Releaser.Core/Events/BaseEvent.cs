using System;
using Newtonsoft.Json;

namespace Releaser.Core.Events
{
	/// <summary>
	/// Base class for all events.
	/// </summary>
	public abstract class BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		protected BaseEvent()
		{
			EventDate = DateTime.UtcNow;
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
		/// Gets or sets internal event date.
		/// </summary>
		public DateTime EventDate { get; set; }
	}
}
