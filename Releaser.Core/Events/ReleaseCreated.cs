using Releaser.Core.Entities;

namespace Releaser.Core.Events
{
	/// <summary>
	/// Event which raises after release creation.
	/// </summary>
	public class ReleaseCreated : BaseEvent
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ReleaseCreated(Release release)
		{
			Release = release;
		}

		/// <summary>
		/// Gets created release.
		/// </summary>
		public Release Release { get; private set; }
	}
}