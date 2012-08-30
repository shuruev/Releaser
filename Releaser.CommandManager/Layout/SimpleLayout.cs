using System.Drawing;
using System.Windows.Forms;

namespace Releaser.CommandManager.Layout
{
	/// <summary>
	/// Simple form layout.
	/// </summary>
	public class SimpleLayout : ILayoutHolder
	{
		/// <summary>
		/// Form size.
		/// </summary>
		public Size Size = Size.Empty;

		/// <summary>
		/// Form location.
		/// </summary>
		public Point Location = Point.Empty;

		/// <summary>
		/// Form window state.
		/// </summary>
		public FormWindowState WindowState = FormWindowState.Normal;

		#region Implementation of ILayoutHolder

		/// <summary>
		/// Gets layout paramteres from specified form.
		/// </summary>
		public virtual void GetLayout(Form form)
		{
			if (form.WindowState == FormWindowState.Normal)
			{
				Size = form.Size;
				Location = form.Location;
			}

			WindowState = form.WindowState;
		}

		/// <summary>
		/// Applies layout paramteres to specified form.
		/// </summary>
		public virtual void SetLayout(Form form)
		{
			form.StartPosition = FormStartPosition.Manual;
			if (Size != Size.Empty)
				form.Size = Size;
			if (Location != Point.Empty)
				form.Location = Location;
			form.WindowState = WindowState;

			Rectangle area = Screen.GetWorkingArea(form);

			if (form.WindowState == FormWindowState.Normal)
			{
				if (form.Width > area.Width)
					form.Width = area.Width;
				if (form.Height > area.Height)
					form.Height = area.Height;

				if (form.Left < area.Left)
					form.Left += area.Left - form.Left;
				if (form.Top < area.Top)
					form.Top += area.Top - form.Top;

				if (form.Right > area.Right)
					form.Left -= form.Right - area.Right;
				if (form.Bottom > area.Bottom)
					form.Top -= form.Bottom - area.Bottom;
			}
		}

		#endregion
	}
}
