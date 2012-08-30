using System;
using Releaser.Core.Events;
using ServiceStack.Text;

namespace Releaser.Core.Exceptions
{
	/// <summary>
	/// Exception occured when view can't apply event.
	/// </summary>
	public class EventNotSupportedException : ArgumentException
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public EventNotSupportedException(BaseEvent @event)
			: base("Event {0} is not supported.".Fmt(@event.Name))
		{
		}
	}
}
