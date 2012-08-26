using System;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Event which raises after adding releaser.
	/// </summary>
	public class ReleaserAdded : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ReleaserAdded(string projectId, string userId)
		{
			ProjectId = projectId;
			UserId = userId;
		}

		/// <summary>
		/// Gets or sets project ID.
		/// </summary>
		public string ProjectId { get; set; }

		/// <summary>
		/// Gets or sets user ID.
		/// </summary>
		public string UserId { get; set; }
	}
}