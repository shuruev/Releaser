using Releaser.Core;
using Releaser.Core.CommandHandlers;
using Releaser.Core.Denormalizer;
using Releaser.Core.EntityStore;
using Releaser.Core.EventStore;
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
			Engine = new CommandEngine(
				new CommandHandlerFactory(
					new FileEntityStore(@"C:\Temp\ReleaserData")),
				new FileEventStore(@"C:\Temp\ReleaserData\EventStore.dat"),
				new Denormalizer(
					new ViewFactory()));
		}

		/// <summary>
		/// Gets static command engine.
		/// </summary>
		public static CommandEngine Engine { get; private set; }
	}
}
