using System.Collections.Generic;
using MongoDB.Driver;

namespace Releaser.Core.MongoDb
{
	/// <summary>
	/// Interface for working with MongoDb database.
	/// </summary>
	public interface IMongoDb
	{
		/// <summary>
		/// Saves entity to database.
		/// </summary>
		void SaveEntity<T>(T entity);

		/// <summary>
		/// Inserts new entities to database.
		/// </summary>
		void InsertEntities<T>(IEnumerable<T> entities);

		/// <summary>
		/// Gets entity from database.
		/// </summary>
		T GetEntity<T>(IMongoQuery query);

		/// <summary>
		/// Gets entities from database.
		/// </summary>
		MongoCursor<T> GetEntities<T>(IMongoQuery query);

		/// <summary>
		/// Deletes entity from database.
		/// </summary>
		void DeleteEntity<T>(IMongoQuery query);
	}
}
