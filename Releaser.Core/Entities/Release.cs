using System;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Represents release.
	/// </summary>
	public class Release : AggregateRoot
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Release(
			string code,
			string versionCode,
			string projectId,
			string userId,
			string comment)
		{
			VersionCode = versionCode;
			ProjectId = projectId;
			UserId = userId;
			Comment = comment;

			Id = code;
			ReleaseDate = DateTime.UtcNow;

			Apply(new ReleaseCreated(this));
		}

		/// <summary>
		/// Gets release version code.
		/// </summary>
		public string VersionCode { get; private set; }

		/// <summary>
		/// Gets project ID.
		/// </summary>
		public string ProjectId { get; private set; }

		/// <summary>
		/// Gets user ID.
		/// </summary>
		public string UserId { get; private set; }

		/// <summary>
		/// Gets release date.
		/// </summary>
		public DateTime ReleaseDate { get; private set; }

		/// <summary>
		/// Gets release comment.
		/// </summary>
		public string Comment { get; private set; }

		/// <summary>
		/// Changes release comment.
		/// </summary>
		public void ChangeComment(string comment)
		{
			Comment = comment;
			Apply(new ReleaseCommentChanged(Id, comment));
		}
	}
}