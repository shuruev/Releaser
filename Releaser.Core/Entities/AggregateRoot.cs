using System.Collections.Generic;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Base class for aggregate root entities.
	/// </summary>
	public class AggregateRoot
	{
		private readonly List<BaseEvent> m_changes = new List<BaseEvent>();

		/// <summary>
		/// Returns all changes with entity.
		/// </summary>
		public List<BaseEvent> GetChanges()
		{
			return new List<BaseEvent>(m_changes);
		}

		protected void Apply(BaseEvent @event)
		{
			m_changes.Add(@event);
		}
	}
}
