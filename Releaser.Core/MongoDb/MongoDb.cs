using System.Collections.Generic;
using MongoDB.Driver;

namespace Releaser.Core.MongoDb
{
	/// <summary>
	/// Class for working with MongoDb database.
	/// </summary>
	public class MongoDb : IMongoDb
	{
		private readonly MongoDatabase m_db;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public MongoDb(string url, string databaseName)
		{
			var server = MongoServer.Create(new MongoUrl(url));
			m_db = server.GetDatabase(databaseName);
		}

		/// <summary>
		/// Saves entity to database.
		/// </summary>
		public void SaveEntity<T>(T entity)
		{
			GetCollection<T>().Insert(entity, SafeMode.True);
		}

		/// <summary>
		/// Saves entities to database.
		/// </summary>
		public void SaveEntities<T>(IEnumerable<T> entities)
		{
			GetCollection<T>().InsertBatch(entities, SafeMode.True);
		}

		/// <summary>
		/// Gets entity from database.
		/// </summary>
		public T GetEntity<T>(IMongoQuery query)
		{
			return GetCollection<T>().FindOneAs<T>(query);
		}

		/// <summary>
		/// Gets entities from database.
		/// </summary>
		public MongoCursor<T> GetEntities<T>(IMongoQuery query)
		{
			return GetCollection<T>().FindAs<T>(query);
		}

		/// <summary>
		/// Deletes entity from database.
		/// </summary>
		public void DeleteEntity<T>(IMongoQuery query)
		{
			GetCollection<T>().Remove(query);
		}

		/// <summary>
		/// Gets mongo collection for entity type.
		/// </summary>
		private MongoCollection GetCollection<T>()
		{
			return m_db.GetCollection(typeof(T).FullName);
		}
	}
}
