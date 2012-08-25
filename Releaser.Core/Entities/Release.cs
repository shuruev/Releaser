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
			Guid projectId,
			Guid userId,
			string comment)
		{
			Code = code;
			VersionCode = versionCode;
			ProjectId = projectId;
			UserId = userId;
			Comment = comment;

			Id = Guid.NewGuid();
			ReleaseDate = DateTime.UtcNow;

			Apply(new ReleaseCreated(this));
		}

		/// <summary>
		/// Gets release ID.
		/// </summary>
		public Guid Id { get; private set; }

		/// <summary>
		/// Gets release code.
		/// </summary>
		public string Code { get; private set; }

		/// <summary>
		/// Gets release version code.
		/// </summary>
		public string VersionCode { get; private set; }

		/// <summary>
		/// Gets project ID.
		/// </summary>
		public Guid ProjectId { get; private set; }

		/// <summary>
		/// Gets user ID.
		/// </summary>
		public Guid UserId { get; private set; }

		/// <summary>
		/// Gets release date.
		/// </summary>
		public DateTime ReleaseDate { get; private set; }

		/// <summary>
		/// Gets release comment.
		/// </summary>
		public string Comment { get; private set; }
	}
}