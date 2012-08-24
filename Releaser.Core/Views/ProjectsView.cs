using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.Events;
using Releaser.Core.Exceptions;

namespace Releaser.Core.Views
{
	/// <summary>
	/// View with projects.
	/// </summary>
	public class ProjectsView : IView
	{
		private readonly ConcurrentDictionary<string, Project> m_projects = new ConcurrentDictionary<string, Project>();

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
		}
	}
}
