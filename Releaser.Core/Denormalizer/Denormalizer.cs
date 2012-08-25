using System.Collections.Generic;
using Releaser.Core.Events;
using Releaser.Core.Views;

namespace Releaser.Core.Denormalizer
{
	/// <summary>
	/// Fills data in all projections.
	/// </summary>
	public class Denormalizer : IDenormalizer
	{
		private readonly IViewFactory m_factory;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Denormalizer(IViewFactory factory)
		{
			m_factory = factory;
		}

		/// <summary>
		/// Fills data in projections.
		/// </summary>
		public void Denormalize(IEnumerable<BaseEvent> events)
		{
			foreach (var @event in events)
			{
				var views = m_factory.GetAffectedViews(@event);
				foreach (var view in views)
				{
					view.Apply(@event);
				}
			}
		}
	}
}
