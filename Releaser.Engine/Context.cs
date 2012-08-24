using Releaser.Core.CommandHandlers;
using Releaser.Core.Commands;

namespace Releaser.Engine
{
	/// <summary>
	/// Static class for context data.
	/// </summary>
	public static class Context
	{
		static Context()
		{
			HandlerFactory = new CommandHandlerFactory();
		}

		/// <summary>
		/// Gets commands handler.
		/// </summary>
		public static CommandHandlerFactory HandlerFactory
		{
			get; private set;
		}
	}
}
