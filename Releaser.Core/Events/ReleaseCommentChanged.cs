using System;

namespace Releaser.Core.Events
{
	/// <summary>
	/// Event which raises after changing release comment.
	/// </summary>
	public class ReleaseCommentChanged : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ReleaseCommentChanged(
			string id,
			string comment)
		{
			Id = id;
			Comment = comment;
		}

		/// <summary>
		/// Gets release ID.
		/// </summary>
		public string Id { get; private set; }

		/// <summary>
		/// Gets new release comment.
		/// </summary>
		public string Comment { get; set; }
	}
}