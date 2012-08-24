using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Releaser.Core.Events;
using ServiceStack.Text;
using JsonSerializer = ServiceStack.Text.JsonSerializer;

namespace Releaser.Core.CommandStore
{
	/// <summary>
	/// Stores data to append-only file.
	/// </summary>
	public class FileEventStore : IEventStore
	{
		private readonly string m_filePath;
		private readonly object m_sync = new object();

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public FileEventStore(string filePath)
		{
			m_filePath = filePath;
		}

		/// <summary>
		/// Saves event to a store.
		/// </summary>
		public void SaveEvents(IEnumerable<BaseEvent> events)
		{
			lock (m_sync)
			{
				using (var writer = new FileStream(m_filePath, FileMode.Append, FileAccess.Write))
				{
					foreach (BaseEvent @event in events)
					{
						var sc = new StoredCommand
						{
							Type = @event.GetType().FullName,
							Json = JsonConvert.SerializeObject(@event),
							StoreTime = DateTime.UtcNow
						};

						byte[] data = JsonConvert.SerializeObject(sc).ToUtf8Bytes();
						byte[] size = BitConverter.GetBytes(data.Length);

						writer.Write(size, 0, size.Length);
						writer.Write(data, 0, data.Length);
					}
				}
			}
		}

		/// <summary>
		/// Reads all events.
		/// </summary>
		public IEnumerable<BaseEvent> ReadAllEvents()
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
						yield return (BaseEvent)JsonSerializer.DeserializeFromString(sc.Json, type);
					}
				}
			}
		}
	}
}
