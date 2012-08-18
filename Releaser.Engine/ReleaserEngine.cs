using ServiceStack.WebHost.Endpoints;

namespace Releaser.Engine
{
	/// <summary>
	/// Releaser engine.
	/// </summary>
	public class ReleaserEngine : AppHostHttpListenerBase
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ReleaserEngine()
			: base(
				"ReleaserEngine",
				typeof(CommandService).Assembly) { }

		/// <summary>
		/// Configures server.
		/// </summary>
		public override void Configure(Funq.Container container)
		{
			SetConfig(new EndpointHostConfig { DebugMode = true });
		}
	}
}
