using System.Collections.Generic;
using Releaser.Core.Events;

namespace Releaser.Core.Views
{
	/// <summary>
	/// Interface for views.
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Gets list of command classes which change view.
		/// </summary>
		List<string> SupportedEvents { get; }

		/// <summary>
		/// Handles command and changes the view.
		/// </summary>
		void Apply(BaseEvent @event);
	}
}
