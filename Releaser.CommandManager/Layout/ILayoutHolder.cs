using System.Windows.Forms;

namespace Releaser.CommandManager.Layout
{
	/// <summary>
	/// Allows form to save its layout.
	/// </summary>
	public interface ILayoutHolder
	{
		/// <summary>
		/// Gets layout paramteres from specified form.
		/// </summary>
		void GetLayout(Form form);

		/// <summary>
		/// Applies layout paramteres to specified form.
		/// </summary>
		void SetLayout(Form form);
	}
}
