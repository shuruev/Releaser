using System.Collections.Generic;
using Releaser.Core.Events;

namespace Releaser.Core.EventStore
{
	/// <summary>
	/// Interface for storing events.
	/// </summary>
	public interface IEventStore
	{
		/// <summary>
		/// Saves event to a store.
		/// </summary>
		void SaveEvents(IEnumerable<BaseEvent> events);

		/// <summary>
		/// Reads all events.
		/// </summary>
		IEnumerable<BaseEvent> ReadAllEvents();
	}
}
