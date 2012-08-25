﻿using System;
using System.Collections.Generic;
using Releaser.Core.CommandHandlers;
using Releaser.Core.Commands;
using Releaser.Core.Denormalizer;
using Releaser.Core.Events;
using Releaser.Core.EventStore;
using Releaser.Core.Exceptions;

namespace Releaser.Core
{
	/// <summary>
	/// Class for processing events.
	/// </summary>
	public class CommandEngine
	{
		private readonly CommandHandlerFactory m_factory;
		private readonly IEventStore m_store;
		private readonly IDenormalizer m_denormalizer;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CommandEngine(
			CommandHandlerFactory factory,
			IEventStore store,
			IDenormalizer denormalizer)
		{
			m_factory = factory;
			m_store = store;
			m_denormalizer = denormalizer;
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		public void ExecuteCommand(BaseCommand command)
		{
			var handler = m_factory.ResolveHandler(command);
			if (handler == null)
				throw new CommandNotSupportedException(command);

			var events = handler.Execute(command);
			m_store.SaveEvents(events);
			m_denormalizer.Denormalize(events);
		}
	}
}
