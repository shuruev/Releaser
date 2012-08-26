using System;
using Releaser.Core.Events;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Represents configuration.
	/// </summary>
	public class Configuration : AggregateRoot
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Configuration()
		{
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Configuration(
			string code,
			string name,
			string description)
		{
			Name = name;
			Description = description;

			Id = code;
			CreationDate = DateTime.UtcNow;

			Apply(new ConfigurationCreated(this));
		}

		/// <summary>
		/// Gets or sets configuration name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets configuration description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets creation date.
		/// </summary>
		public DateTime CreationDate { get; set; }
	}
}