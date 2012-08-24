using System.Collections.Generic;
using Releaser.Core.Events;

namespace Releaser.Core.CommandStore
{
	/// <summary>
	/// Interface for storing events.
	/// </summary>
	public interface IEventStore
	{
		/// <summary>
		/// Saves event to a store.
		/// </summary>
		void SaveEvent(BaseEvent @event);

		/// <summary>
		/// Reads all events.
		/// </summary>
		IEnumerable<BaseEvent> ReadAllEvents();
	}
}