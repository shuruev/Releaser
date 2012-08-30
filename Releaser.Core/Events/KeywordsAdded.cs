using System;
using System.Collections.Generic;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Event which raises after adding keywords.
	/// </summary>
	public class KeywordsAdded : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public KeywordsAdded(string projectId, List<string> keywords)
		{
			ProjectId = projectId;
			Keywords = keywords;
		}

		/// <summary>
		/// Gets or sets project ID.
		/// </summary>
		public string ProjectId { get; set; }

		/// <summary>
		/// Gets or sets added keywords.
		/// </summary>
		public List<string> Keywords { get; set; }
	}
}