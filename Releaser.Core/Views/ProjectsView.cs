
using System;
using System.Collections.Generic;
using Releaser.Core.Entities;
using Releaser.Core.Events;
using Releaser.Core.Exceptions;

namespace Releaser.Core.Views
{
	/// <summary>
	/// View with projects.
	/// TODO: Make it concurrent.
	/// </summary>
	public class ProjectsView : IView
	{
		private readonly Dictionary<Guid, Project> m_projects = new Dictionary<Guid, Project>();

		// private readonly ConcurrentDictionary<string, List<Release>> m_releases = new ConcurrentDictionary<string, List<Release>>();

		/// <summary>
		/// Gets list of command classes which change view.
		/// Todo: Rework with attributes.
		/// </summary>
		public List<string> SupportedEvents
		{
			get
			{
				return new List<string>
				{
					typeof(ProjectCreated).FullName
				};
			}
		}

		/// <summary>
		/// Handles command and changes the view.
		/// </summary>
		public void Apply(BaseEvent @event)
		{
			if (@event is ProjectCreated)
			{
				ApplyCreateProject(@event as ProjectCreated);
				return;
			}

			throw new EventNotSupportedException(@event);
		}

		private void ApplyCreateProject(ProjectCreated @event)
		{
			var project = @event.Project;
			m_projects.Add(project.Id, project);
		}
	}
}
