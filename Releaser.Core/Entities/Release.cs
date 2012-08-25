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
		public Release()
		{
		}

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
		/// Gets or sets release version code.
		/// </summary>
		public string VersionCode { get; set; }

		/// <summary>
		/// Gets or sets project ID.
		/// </summary>
		public string ProjectId { get; set; }

		/// <summary>
		/// Gets or sets user ID.
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Gets or sets release date.
		/// </summary>
		public DateTime ReleaseDate { get; set; }

		/// <summary>
		/// Gets or sets release comment.
		/// </summary>
		public string Comment { get; set; }

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