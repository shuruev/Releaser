﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Releaser.Core.Events;

namespace Releaser.Core.EventStore
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
				using (var fs = new FileStream(m_filePath, FileMode.Append, FileAccess.Write))
				using (var writer = new BinaryWriter(fs, Encoding.UTF8))
				{
					foreach (var @event in events)
					{
						var sc = new StoredCommand
						{
							Type = @event.GetType().FullName,
							Json = JsonConvert.SerializeObject(@event),
							StoreTime = DateTime.UtcNow
						};

						writer.Write(JsonConvert.SerializeObject(sc));
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
				using (var fs = new FileStream(m_filePath, FileMode.Open, FileAccess.Read))
				using (var reader = new BinaryReader(fs, Encoding.UTF8))
				{
					var pos = 0;
					var length = (int)reader.BaseStream.Length;

					while (pos < length)
					{
						var json = reader.ReadString();
						var sc = JsonConvert.DeserializeObject<StoredCommand>(json);
						var type = Type.GetType(sc.Type);
						yield return (BaseEvent) JsonConvert.DeserializeObject(sc.Json, type);

						pos += sizeof(int);
					}
				}
			}
		}
	}
}
