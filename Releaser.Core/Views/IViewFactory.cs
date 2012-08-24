using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Events;

namespace Releaser.Core.Views
{
	/// <summary>
	/// Interface for factory of views.
	/// </summary>
	public interface IViewFactory
	{
		/// <summary>
		/// Return list of affected views.
		/// </summary>
		List<IView> GetAffectedViews(BaseEvent @event);
	}
}
