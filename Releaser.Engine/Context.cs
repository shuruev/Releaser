using Releaser.Core;
using Releaser.Core.CommandHandlers;
using Releaser.Core.Denormalizer;
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
				new CommandHandlerFactory(),
				new FileEventStore("EventStore.dat"),
				new Denormalizer(
					new ViewFactory()));
		}

		/// <summary>
		/// Gets static command engine.
		/// </summary>
		public static CommandEngine Engine { get; private set; }
	}
}
