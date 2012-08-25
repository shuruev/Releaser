using System;
using System.Collections.Generic;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Base class for aggregate root entities.
	/// </summary>
	public abstract class AggregateRoot
	{
		private readonly List<BaseEvent> m_changes = new List<BaseEvent>();

		/// <summary>
		/// Gets or sets aggregate root ID.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Returns all changes with entity.
		/// </summary>
		public List<BaseEvent> GetChanges()
		{
			return new List<BaseEvent>(m_changes);
		}

		/// <summary>
		/// Adds event to changes.
		/// </summary>
		protected void Apply(BaseEvent @event)
		{
			m_changes.Add(@event);
		}
	}
}
