using System;
using Releaser.Core.Commands;
using Releaser.Core.CommandStore;
using Releaser.Core.Denormalizer;

namespace Releaser.Core
{
	/// <summary>
	/// Engine for executing commands.
	/// </summary>
	public class CommandHandler : IDisposable
	{
		private readonly ICommandStore m_store;
		private readonly IDenormalizer m_denormalizer;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CommandHandler(
			ICommandStore store,
			IDenormalizer denormalizer)
		{
			m_store = store;
			m_denormalizer = denormalizer;
		}

		/// <summary>
		/// Executes command.
		/// </summary>
		public void ExecuteCommand(BaseCommand command)
		{
			m_denormalizer.Denormalize(command);
			m_store.SaveCommand(command);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			m_store.Dispose();
		}
	}
}
