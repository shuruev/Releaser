using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Releaser.Core.EventStore;
using Releaser.Core.Events;

namespace ReleaserConsole
{
	internal class Program
	{
		private static void Main()
		{
			var sw = new Stopwatch();
			sw.Start();

			FileEventStore fs = new FileEventStore("this.dat");

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

				var command = new CreateProject();
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

			var command = new CreateProject();
			command.Project = new Project();
			command.Project.Name = "NewProject";
			command.Project.Path = "PublicationStorage";
			command.Project.DisplayName = "New project";

			engine.ExecuteCommand(command);*/
	}
}
