using System;
using System.Collections.Generic;
using System.Linq;
using Releaser.Core.Commands;
using Releaser.Core.Events;

namespace Releaser.Core.Views
{
	/// <summary>
	/// Factory for views.
	/// </summary>
	public class ViewFactory : IViewFactory
	{
		private readonly Dictionary<string, List<IView>> m_views = new Dictionary<string, List<IView>>();

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ViewFactory()
		{
			var type = typeof(IView);
			var viewTypes = AppDomain.CurrentDomain
				.GetAssemblies().ToList()
				.SelectMany(s => s.GetTypes())
				.Where(t => type.IsAssignableFrom(t) && t.IsClass);

			foreach (Type viewType in viewTypes)
			{
				IView view = (IView)Activator.CreateInstance(viewType);
				foreach (string command in view.SupportedEvents)
				{
					if (!m_views.ContainsKey(command))
						m_views[command] = new List<IView>();

					m_views[command].Add(view);
				}
			}
		}

		/// <summary>
		/// Return list of affected views.
		/// </summary>
		public List<IView> GetAffectedViews(BaseEvent @event)
		{
			if (!m_views.ContainsKey(@event.Name))
				return new List<IView>();

			return m_views[@event.Name];
		}
	}
}
