using Releaser.Core.Commands;

namespace Releaser.Core.Denormalizer
{
	/// <summary>
	/// Interface for filling projections.
	/// </summary>
	public interface IDenormalizer
	{
		/// <summary>
		/// Fills data in projections.
		/// </summary>
		void Denormalize(BaseCommand command);
	}
}