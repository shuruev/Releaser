using System;
using System.Diagnostics;
using Autofac;
using Releaser.Core.Client;
using Releaser.Core.Commands;
using Releaser.Core.CommandStore;
using Releaser.Core.Entities;
using Releaser.Core.Ioc;

namespace ReleaserConsole
{
	internal class Program
	{
		private static void Main()
		{
			/*9FileCommandStore store = new FileCommandStore(@"c:\!Data\Dropbox\Projects\Releaser\Releaser.Engine\bin\Debug\commands.bin");
			foreach (BaseCommand cmd in store.ReadAllCommands())
			{
				Console.WriteLine(cmd.Name);
			}*/

			/*Stopwatch sw = new Stopwatch();
			sw.Start();

			FileCommandStore store = new FileCommandStore(@"c:\!Data\Dropbox\Projects\Releaser\Releaser.Engine\bin\Debug\commands.bin");
			foreach (BaseCommand cmd in store.ReadAllCommands())
			{
				Console.WriteLine(cmd.Name);
			}

			sw.Stop();
			Console.WriteLine("{0}ms...", sw.ElapsedMilliseconds);
			Console.ReadKey();*/

			for (int i = 0; i < 2; i++)
			{
				EngineClient client = new EngineClient("http://localhost:5557");

				var command = new CreateProjectCommand();
				command.Project = new Project();
				command.Project.Name = "NewProject";
				command.Project.Path = "PublicationStorage";
				command.Project.DisplayName = "New project";

				client.SendCommand(command);
			}

			/*sw.Stop();
			Console.WriteLine("{0}ms...", sw.ElapsedMilliseconds);
			Console.ReadKey();

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
