using System;
using Releaser.Core.Entities;

namespace Releaser.Core.Events
{
	/// <summary>
	/// Event which raises after project creation.
	/// </summary>
	public class ProjectCreated : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ProjectCreated(Project project)
		{
			Project = project;
		}

		/// <summary>
		/// Gets or sets created project.
		/// </summary>
		public Project Project { get; set; }
	}
}
