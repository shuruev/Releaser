using Newtonsoft.Json;

namespace Releaser.Core.Commands
{
	/// <summary>
	/// Base class for commands.
	/// </summary>
	public abstract class BaseCommand
	{
		/// <summary>
		/// Gets command name.
		/// </summary>
		[JsonIgnore]
		public string Name
		{
			get { return GetType().FullName; }
		}
	}
}
