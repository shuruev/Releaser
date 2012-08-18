using System;
using Releaser.Core;
using Releaser.Core.CommandStore;
using Releaser.Core.Denormalizer;
using Releaser.Core.Views;

namespace Releaser.Engine
{
	/// <summary>
	/// Static class for context data.
	/// </summary>
	public static class Context
	{
		static Context()
		{
			Handler = new CommandHandler(
				new FileCommandStore("commands.bin"),
				new Denormalizer(new ViewFactory()));
		}

		/// <summary>
		/// Gets commands handler.
		/// </summary>
		public static CommandHandler Handler
		{
			get; private set;
		}
	}
}
