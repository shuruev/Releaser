using System;
using Releaser.Core.Entities;

namespace Releaser.Core.EntityStore
{
	/// <summary>
	/// Interface for storing entities.
	/// </summary>
	public interface IEntityStore
	{
		/// <summary>
		/// Reads object by specified ID.
		/// </summary>
		T Read<T>(string id);

		/// <summary>
		/// Writes specified object.
		/// </summary>
		void Write(AggregateRoot entity);
	}
}
