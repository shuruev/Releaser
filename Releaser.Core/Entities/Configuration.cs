using System;
using System.Collections.Generic;
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
			Deployers = new List<string>();
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

			Deployers = new List<string>();

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

		/// <summary>
		/// Gets or sets list of users which can deploy on the configuration.
		/// </summary>
		public List<string> Deployers { get; set; }

		/// <summary>
		/// Adds the specified user ID as deployer.
		/// </summary>
		public void AddDeployer(string userId)
		{
			Deployers.Add(userId);

			Apply(new DeployerAdded(Id, userId));
		}
	}
}