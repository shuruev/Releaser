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
			EventStore = new FileEventStore(@"C:\Temp\ReleaserData\EventStore.dat");

			Engine = new CommandEngine(
				new CommandHandlerFactory(
					new FileEntityStore(@"C:\Temp\ReleaserData")),
				EventStore,
				new Denormalizer(
					new ViewFactory()));
		}

		/// <summary>
		/// Initializes all context variables.
		/// </summary>
		public static void Initialize()
		{
		}

		/// <summary>
		/// Gets static command engine.
		/// </summary>
		public static CommandEngine Engine { get; private set; }

		/// <summary>
		/// Gets static command engine.
		/// </summary>
		public static IEventStore EventStore { get; private set; }
	}
}
