using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Events;

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
		void Denormalize(IEnumerable<BaseEvent> events);
	}
}
