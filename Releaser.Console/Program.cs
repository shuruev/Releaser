using Autofac;
using Releaser.Core.Client;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.Ioc;

namespace Releaser.Console
{
	internal class Program
	{
		private static void Main()
		{
			EngineClient client = new EngineClient("http://localhost:5557");

			var command = new CreateProjectCommand();
			command.Project = new Project();
			command.Project.Name = "NewProject";
			command.Project.Path = "PublicationStorage";
			command.Project.DisplayName = "New project";

			client.SendCommand(command);

			/*AutofacResolver resolver = GetResolver();

			CommandEngine engine = new CommandEngine(resolver);

			var command = new CreateProjectCommand();
			command.Project = new Project();
			command.Project.Name = "NewProject";
			command.Project.Path = "PublicationStorage";
			command.Project.DisplayName = "New project";

			engine.ExecuteCommand(command);*/
		}
	}
}
