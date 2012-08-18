using System.Collections.Generic;
using Releaser.Core.Commands;

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
		List<string> SupportedCommands { get; }

		/// <summary>
		/// Handles command and changes the view.
		/// </summary>
		void Handle(BaseCommand command);
	}
}