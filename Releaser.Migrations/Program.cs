using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.EventStore;

namespace Releaser.Migrations
{
	public class Program
	{
		private static FileEntityStore s_entityStore;
		private static FileEventStore s_eventStore;

		public static void Main()
		{
			s_entityStore = new FileEntityStore(@"C:\Temp\ReleaserData");
			s_eventStore = new FileEventStore(@"C:\Temp\ReleaserData\EventStore.dat");

			LoadUsers();
			LoadProjects();
			LoadReleases();

			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		private static void LoadUsers()
		{
			Console.WriteLine("Loading users...");

			var sw = new Stopwatch();
			sw.Start();

			string dataFile = File.ReadAllText(@"c:\!Data\Dropbox\Projects\Releaser\Data.tmp\ReleaserData.xml");

			var xml = XElement.Parse(dataFile);

			var userNodes = xml.Elements("User").ToList();
			foreach (XElement userNode in userNodes)
			{
				var user = new User(
					userNode.Element("UserLogin").Value,
					userNode.Element("UserCode").Value,
					userNode.Element("UserName").Value);
				user.Id = userNode.Element("UserUid").Value;

				s_entityStore.Write(user);
				s_eventStore.SaveEvents(user.GetChanges());
			}

			sw.Stop();

			Console.WriteLine(
				"{0} users were loaded ({1}ms).",
				userNodes.Count,
				sw.ElapsedMilliseconds);
		}

		private static void LoadProjects()
		{
			Console.WriteLine("Loading projects...");

			var sw = new Stopwatch();
			sw.Start();

			string dataFile = File.ReadAllText(@"c:\!Data\Dropbox\Projects\Releaser\Data.tmp\ReleaserData.xml");

			var xml = XElement.Parse(dataFile);

			var projectNodes = xml.Elements("Project").ToList();
			foreach (XElement projectNode in projectNodes)
			{
				var project = new Project(
					projectNode.Element("ProjectName").Value,
					projectNode.Element("StoragePath").Value,
					projectNode.Element("StorageCode").Value,
					projectNode.Element("ImageCode").Value
					);
				project.Id = projectNode.Element("ProjectUid").Value;

				s_entityStore.Write(project);
				s_eventStore.SaveEvents(project.GetChanges());
			}

			sw.Stop();

			Console.WriteLine(
				"{0} projects were loaded ({1}ms).",
				projectNodes.Count,
				sw.ElapsedMilliseconds);
		}

		private static void LoadReleases()
		{
			Console.WriteLine("Loading releases...");

			var sw = new Stopwatch();
			sw.Start();

			string dataFile = File.ReadAllText(@"c:\!Data\Dropbox\Projects\Releaser\Data.tmp\ReleaserData.xml");

			var xml = XElement.Parse(dataFile);

			var releaseNodes = xml.Elements("Release").ToList();
			foreach (XElement releaseNode in releaseNodes)
			{
				var release = new Release(
					releaseNode.Element("ReleaseCode").Value,
					releaseNode.Element("VersionCode").Value,
					releaseNode.Element("ProjectUid").Value,
					releaseNode.Element("UserUid").Value,
					releaseNode.Element("ReleaseComment").Value);

				s_entityStore.Write(release);
				s_eventStore.SaveEvents(release.GetChanges());	
			}

			sw.Stop();

			Console.WriteLine(
				"{0} releases were loaded ({1}ms).",
				releaseNodes.Count,
				sw.ElapsedMilliseconds);
		}
	}
}
