using System.Collections.Generic;
using Releaser.Core.Commands;

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
		List<IView> GetAffectedViews(BaseCommand command);
	}
}