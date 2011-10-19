using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbSampleApp
{
	public class TestEntity
	{
		[BsonId]
		public ObjectId Key { get; set; }

		public string Name { get; set; }

		public DateTime Date { get; set; }

		public int[] Values { get; set; }
	}
}
