using System;
using System.Collections.Generic;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Releaser.Core.MongoDb;

namespace MongoDbSampleApp
{
	internal class Program
	{
		private static void Main()
		{
			string mongoDbConnectionString = ConfigurationManager.AppSettings["MongoDb"];
			string databaseName = ConfigurationManager.AppSettings["DatabaseName"];

			IMongoDb mongo = new MongoDb(mongoDbConnectionString, databaseName);
			var server = MongoServer.Create(new MongoUrl(mongoDbConnectionString));

			CreateEntity(mongo);
			CreateEntity(mongo);
			CreateEntity(mongo);

			TestEntity ent = GetEntity(mongo);

			UpdateEntity(mongo, ent);

			WriteInformation(ent);

			TestGroupBy(databaseName, server);

			DeleteEntity(mongo);

			Check(mongo);

			server.DropDatabase(databaseName);

			Console.ReadKey();
		}

		private static void UpdateEntity(IMongoDb mongo, TestEntity ent)
		{
			ent.Values = new[] { 1 };
			mongo.SaveEntity(ent);
		}

		private static void Check(IMongoDb mongo)
		{
			TestEntity ent;
			ent = GetEntity(mongo);

			if (ent == null)
				Console.WriteLine("All entities with name \"TestEntity\" was removed.");
			else
				Console.WriteLine("Something wrong.");
		}

		private static void TestGroupBy(string databaseName, MongoServer server)
		{
			var db = server.GetDatabase(databaseName);
			var collection = db.GetCollection(typeof(TestEntity).FullName);
			IEnumerable<BsonDocument> groups = collection.Group(
				null,
				new GroupByDocument("Name", true),
				new FieldsDocument("Sum", 0),
				new BsonJavaScript("function(obj,prev) { for ( value in obj.Values ) { prev.Sum += obj.Values[value]; } }"),
				null);

			foreach (BsonDocument document in groups)
			{
				Console.WriteLine(document["Sum"]);
			}
		}

		private static void WriteInformation(TestEntity ent)
		{
			Console.WriteLine("Saved entity:");
			Console.WriteLine("Name: {0}", ent.Name);
			Console.WriteLine("Date: {0}", ent.Date);
			Console.Write("Values: ");
			foreach (int value in ent.Values)
				Console.Write("{0} ", value);
			Console.WriteLine();
			Console.WriteLine();
		}

		private static void CreateEntity(IMongoDb mongo)
		{
			TestEntity ent = new TestEntity();
			ent.Name = "TestEntity";
			ent.Date = DateTime.Now;
			ent.Values = new[] { 1, 10, 100 };

			mongo.SaveEntity(ent);
		}

		private static TestEntity GetEntity(IMongoDb mongo)
		{
			var query = new QueryDocument("Name", "TestEntity");
			return mongo.GetEntity<TestEntity>(query);
		}

		private static void DeleteEntity(IMongoDb mongo)
		{
			var query = new QueryDocument("Name", "TestEntity");
			mongo.DeleteEntity<TestEntity>(query);
		}
	}
}
