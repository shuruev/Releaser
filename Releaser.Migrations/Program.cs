using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Releaser.Core.Client;
using Releaser.Core.Commands;

namespace Releaser.Migrations
{
	public class Program
	{
		public static void Main()
		{
			// TODO: Rework it. Write to event store all events.

			var client = new EngineClient("http://localhost:5557");

			LoadProjects(client);
			LoadReleases(client);

			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		private static void LoadProjects(EngineClient client)
		{
			Console.WriteLine("Loading projects...");

			var sw = new Stopwatch();
			sw.Start();

			string dataFile = File.ReadAllText(@"c:\!Data\Dropbox\Projects\Releaser\Data.tmp\ReleaserData.xml");

			var xml = XElement.Parse(dataFile);

			var projectNodes = xml.Elements("Project").ToList();
			foreach (XElement projectNode in projectNodes)
			{
				var command = new CreateProject();
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

		private static void LoadReleases(EngineClient client)
		{
			Console.WriteLine("Loading releases...");

			var sw = new Stopwatch();
			sw.Start();

			string dataFile = File.ReadAllText(@"c:\!Data\Dropbox\Projects\Releaser\Data.tmp\ReleaserData.xml");

			var xml = XElement.Parse(dataFile);

			var releaseNodes = xml.Elements("Release").ToList();
			foreach (XElement releaseNode in releaseNodes)
			{
				var command = new CreateRelease();
				command.ProjectId = releaseNode.Element("ProjectUid").Value;
				command.UserId = releaseNode.Element("UserUid").Value;
				command.VersionCode = releaseNode.Element("VersionCode").Value;
				command.Comment = releaseNode.Element("ReleaseComment").Value;

				client.SendCommand(command);
			}

			sw.Stop();

			Console.WriteLine(
				"{0} releases were loaded ({1}ms).",
				releaseNodes.Count,
				sw.ElapsedMilliseconds);
		}
	}
}
