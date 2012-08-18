using System;
using System.Collections.Generic;
using System.IO;
using Releaser.Core.Commands;
using ServiceStack.Text;

namespace Releaser.Core.CommandStore
{
	/// <summary>
	/// Stores data to append-only file.
	/// </summary>
	public class FileCommandStore : ICommandStore
	{
		private string m_filePath;
		private object m_sync = new object();

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public FileCommandStore(string filePath)
		{
			m_filePath = filePath;
		}

		/// <summary>
		/// Saves command to a store.
		/// </summary>
		public void SaveCommand(BaseCommand command)
		{
			command.StoreTime = DateTime.UtcNow;

			var sc = new StoredCommand
			{
				Type = command.GetType().FullName,
				Json = command.ToJson()
			};

			byte[] data = sc.ToJson().ToUtf8Bytes();
			byte[] size = BitConverter.GetBytes(data.Length);
			lock (m_sync)
			{
				using (var writer = new FileStream(m_filePath, FileMode.Append, FileAccess.Write))
				{
					writer.Write(size, 0, size.Length);
					writer.Write(data, 0, data.Length);
				}
			}
		}

		/// <summary>
		/// Reads all commands.
		/// </summary>
		public IEnumerable<BaseCommand> ReadAllCommands()
		{
			lock (m_sync)
			{
				using (var reader = new FileStream(m_filePath, FileMode.Open, FileAccess.Read))
				{
					byte[] buffer = new byte[4];
					while (reader.Read(buffer, 0, 4) > 0)
					{
						int size = BitConverter.ToInt32(buffer, 0);
						byte[] data = reader.ReadExactly(size);
						string json = data.FromUtf8Bytes();
						var sc = JsonSerializer.DeserializeFromString<StoredCommand>(json);
						var type = AssemblyUtils.FindType(sc.Type);
						yield return (BaseCommand)JsonSerializer.DeserializeFromString(sc.Json, type);
					}
				}
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
		}
	}
}