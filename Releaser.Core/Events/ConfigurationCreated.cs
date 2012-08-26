using Releaser.Core.Entities;

namespace Releaser.Core.Events
{
	/// <summary>
	/// Event which raises after configuration creation.
	/// </summary>
	public class ConfigurationCreated : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ConfigurationCreated(Configuration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Gets or sets created configuration.
		/// </summary>
		public Configuration Configuration { get; set; }
	}
}