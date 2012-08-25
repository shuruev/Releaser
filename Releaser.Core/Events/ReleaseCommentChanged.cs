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
			string releaseId,
			string comment)
		{
			ReleaseId = releaseId;
			ReleaseComment = comment;
		}

		/// <summary>
		/// Gets release ID.
		/// </summary>
		public string ReleaseId { get; private set; }

		/// <summary>
		/// Gets new release comment.
		/// </summary>
		public string ReleaseComment { get; set; }
	}
}