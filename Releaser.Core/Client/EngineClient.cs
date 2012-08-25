using Releaser.Core.Commands;
using Releaser.Core.Dto;
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
			client.Send<object>(new CommandDto
			{
				Json = command.ToJson()
			});
		}
	}
}
