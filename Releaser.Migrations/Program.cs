using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Releaser.Core.Client;
using Releaser.Core.Commands;

namespace Releaser.Migrations
{
	class Program
	{
		static void Main()
		{
			EngineClient client = new EngineClient("http://localhost:5557");

			LoadProjects(client);

			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		private static void LoadProjects(EngineClient client)
		{
			Console.WriteLine("Loading projects...");

			Stopwatch sw = new Stopwatch();
			sw.Start();

			string dataFile = File.ReadAllText(@"c:\!Data\Dropbox\Projects\Releaser\Data.tmp\ReleaserData.xml");

			XElement xml = XElement.Parse(dataFile);

			var projectNodes = xml.Elements("Project").ToList();
			foreach (XElement projectNode in projectNodes)
			{
				var command = new CreateProjectCommand();
				command.ProjectName = projectNode.Element("ProjectName").Value;
				command.ProjectPath = projectNode.Element("StoragePath").Value;
				command.ProjectStorageType = projectNode.Element("StorageCode").Value;
				command.ProjectType = projectNode.Element("ImageCode").Value;

				client.SendCommand(command);
			}

			sw.Stop();

			Console.WriteLine(
				"{0} projects were loaded ({1}ms).",
				projectNodes.Count,
				sw.ElapsedMilliseconds);
		}

	}
}
