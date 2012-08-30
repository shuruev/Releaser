using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Dto;
using Releaser.Core.Events;
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace Releaser.Core.Client
{
	/// <summary>
	/// Client for releaser engine service.
	/// </summary>
	public class EngineClient
	{
		private readonly string m_url;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public EngineClient(string url)
		{
			m_url = url;
		}

		/// <summary>
		/// Sends command to releaser engine.
		/// </summary>
		public void SendCommand(BaseCommand command)
		{
			var client = new JsonServiceClient(m_url);
			client.Send<object>(new RequestDto
			{
				Type = RequestDto.CommandType,
				Json = command.ToJson()
			});
		}

		/// <summary>
		/// Gets all events from event store.
		/// </summary>
		public List<BaseEvent> GetAllEvents()
		{
			var client = new JsonServiceClient(m_url);
			List<BaseEvent> result = client.Send<List<BaseEvent>>(new RequestDto
			{
				Type = RequestDto.QueryType,
				Json = "GetAllEvents"
			});
			return result;
		}
	}
}
