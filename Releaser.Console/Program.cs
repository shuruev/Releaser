using System;
using System.Diagnostics;

namespace ReleaserConsole
{
	internal class Program
	{
		private static void Main()
		{
			var sw = new Stopwatch();
			sw.Start();

			sw.Stop();
			Console.WriteLine("{0}ms...", sw.ElapsedMilliseconds);
			Console.ReadKey();
		}

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

			/*Stopwatch sw = new Stopwatch();
			sw.Start();

			for (int i = 0; i < 10000; i++)
			{
				EngineClient client = new EngineClient("http://localhost:5557");

				var command = new CreateProjectCommand();
				command.ProjectName = "NewProject " + i;
				command.ProjectPath = "PublicationStorage";
				command.ProjectDisplayName = "New project";

				client.SendCommand(command);
			}

			sw.Stop();
			Console.WriteLine("{0}ms...", sw.ElapsedMilliseconds);
			Console.ReadKey();*/

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
