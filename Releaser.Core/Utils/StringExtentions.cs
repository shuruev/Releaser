namespace Releaser.Core.Utils
{
	/// <summary>
	/// Class for extentions for string.
	/// </summary>
	public static class StringExtentions
	{
		/// <summary>
		/// Replaces one or more format items in a specified string with the string representation of a specified object.
		/// </summary>
		public static string F(this string str, params object[] args)
		{
			return string.Format(str, args);
		}
	}
}
