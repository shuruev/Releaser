using System.Configuration;
using Autofac;
using Autofac.Core;
using Releaser.Core;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.Handlers;
using Releaser.Core.Ioc;
using Releaser.Core.MongoDb;

namespace Releaser.Console
{
	internal class Program
	{
		private static void Main()
		{
			MongoDb mongoDb = GetMongoDb();
			AutofacResolver resolver = GetResolver(mongoDb);

			CommandEngine engine = new CommandEngine(resolver);

			var command = new CreateProjectCommand();
			command.Project = new Project();
			command.Project.Name = "NewProject";
			command.Project.Path = "PublicationStorage";
			command.Project.DisplayName = "New project";

			engine.ExecuteCommand(command);
		}

		private static AutofacResolver GetResolver(MongoDb mongoDb)
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<CreateProjectCommandHandler>()
				.WithParameter("mongoDb", mongoDb);

			return new AutofacResolver(builder.Build());
		}

		private static MongoDb GetMongoDb()
		{
			var mongoDbUrl = ConfigurationManager.AppSettings["MongoDb"];
			var databaseName = ConfigurationManager.AppSettings["DatabaseName"];

			return new MongoDb(mongoDbUrl, databaseName);
		}
	}
}
