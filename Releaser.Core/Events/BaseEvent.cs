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
		/// Gets command name.
		/// </summary>
		[JsonIgnore]
		public string Name
		{
			get { return GetType().FullName; }
		}
	}
}
