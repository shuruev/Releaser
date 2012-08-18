using Releaser.Core.Commands;
using Releaser.Core.Views;

namespace Releaser.Core.Denormalizer
{
	/// <summary>
	/// Fills data in all projections.
	/// </summary>
	public class Denormalizer : IDenormalizer
	{
		private readonly IViewFactory m_factory;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public Denormalizer(IViewFactory factory)
		{
			m_factory = factory;
		}

		/// <summary>
		/// Fills data in projections.
		/// </summary>
		public void Denormalize(BaseCommand command)
		{
			var views = m_factory.GetAffectedViews(command);
			views.ForEach(v => v.Handle(command));
		}
	}
}