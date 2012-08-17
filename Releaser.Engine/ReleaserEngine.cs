using ServiceStack.WebHost.Endpoints;

namespace Releaser.Engine
{
	public class ReleaserEngine : AppHostHttpListenerBase
	{
		public ReleaserEngine()
			: base(
				"ReleaserEngine",
				typeof(CommandService).Assembly) { }

		public override void Configure(Funq.Container container)
		{
		}
	}
}