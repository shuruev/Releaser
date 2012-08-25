using System;
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

			Id = Guid.NewGuid();
			CreationDate = DateTime.UtcNow;

			Apply(new ProjectCreated(this));
		}

		/// <summary>
		/// Gets entity identifier.
		/// </summary>
		public Guid Id { get; private set; }

		/// <summary>
		/// Gets project name.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Gets path to project version.
		/// </summary>
		public string Path { get; private set; }

		/// <summary>
		/// Gets type of storage.
		/// </summary>
		public string StorageType { get; private set; }

		/// <summary>
		/// Gets type of project.
		/// </summary>
		public string ProjectType { get; private set; }

		/// <summary>
		/// Gets project creation date.
		/// </summary>
		public DateTime CreationDate { get; private set; }
	}
}
