using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
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
		/// Todo: Rework with attributes?
		/// </summary>
		public List<string> SupportedCommands
		{
			get
			{
				return new List<string>
				{
					typeof (CreateProjectCommand).FullName
				};
			}
		}

		/// <summary>
		/// Handles command and changes the view.
		/// </summary>
		public void Handle(BaseCommand command)
		{
			if (command is CreateProjectCommand)
			{
				HandleCreateProject(command as CreateProjectCommand);
				return;
			}

			throw new CommandNotSupportedException(command);
		}

		private void HandleCreateProject(CreateProjectCommand command)
		{
			if (!m_projects.TryAdd(command.Project.Name, command.Project))
				throw new ArgumentException(string.Format("Project with name '{0}' exists in database."));
		}
	}
}
