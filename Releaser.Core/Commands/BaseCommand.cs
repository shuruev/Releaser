using System;
using ProtoBuf;

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
		public string Name
		{
			get { return GetType().FullName; }
		}

		/// <summary>
		/// Gets or sets time when command was stored.
		/// </summary>
		public DateTime StoreTime { get; set; }
	}
}
