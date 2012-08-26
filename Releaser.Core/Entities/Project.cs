using System;
using System.Collections.Generic;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Represents project.
	/// </summary>
	public class Project : AggregateRoot
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Project()
		{
			Releasers = new List<string>();
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Project(
			string name,
			string path,
			string storageType,
			string projectType)
		{
			Name = name;
			Path = path;
			StorageType = storageType;
			ProjectType = projectType;

			// TODO: maybe change to project name?
			Id = Guid.NewGuid().ToString();
			CreationDate = DateTime.UtcNow;

			Releasers = new List<string>();

			Apply(new ProjectCreated(this));
		}

		/// <summary>
		/// Gets or sets project name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets path to project version.
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets type of storage.
		/// </summary>
		public string StorageType { get; set; }

		/// <summary>
		/// Gets or sets type of project.
		/// </summary>
		public string ProjectType { get; set; }

		/// <summary>
		/// Gets or sets project creation date.
		/// </summary>
		public DateTime CreationDate { get; set; }

		/// <summary>
		/// Gets or sets list of releasers.
		/// </summary>
		public List<string> Releasers { get; set; }

		/// <summary>
		/// Adds the specified user as releaser.
		/// </summary>
		public void AddReleaser(string userId)
		{
			Releasers.Add(userId);

			Apply(new ReleaserAdded(Id, userId));
		}
	}
}
