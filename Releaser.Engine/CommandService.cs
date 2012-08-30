using System;
using System.Diagnostics;
using System.Linq;
using Releaser.Core;
using Releaser.Core.Commands;
using Releaser.Core.Dto;
using Releaser.Core.EventStore;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;

namespace Releaser.Engine
{
	/// <summary>
	/// Service which processes commands requests.
	/// </summary>
	public class CommandService : RestServiceBase<RequestDto>
	{
		private readonly CommandEngine m_engine;
		private readonly IEventStore m_store;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CommandService()
		{
			m_engine = Context.Engine;
			m_store = Context.EventStore;
		}

		/// <summary>
		/// Raises on POST request with command.
		/// </summary>
		public override object OnPost(RequestDto request)
		{
			try
			{
				if (request.Type == RequestDto.CommandType)
				{
					Stopwatch sw = new Stopwatch();
					sw.Start();

					var command = request.Json.FromJson<BaseCommand>();
					m_engine.ExecuteCommand(command);

					sw.Stop();
					Console.WriteLine(
						"Command '{0}' was processed in {1}ms.",
						command.Name,
						sw.ElapsedMilliseconds);

					return null;
				}

				if (request.Type == RequestDto.QueryType)
				{
					if (request.Json == "GetAllEvents")
					{
						return m_store.ReadAllEvents().ToList();
					}
				}

				throw new InvalidOperationException("Unknown command type: {0}.".Fmt(request.Type));
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(e.ToString());
				Console.ResetColor();
				throw;
			}
		}
	}
}
