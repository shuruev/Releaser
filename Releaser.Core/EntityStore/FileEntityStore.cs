using System;
using System.IO;
using Newtonsoft.Json;
using Releaser.Core.Entities;
using Releaser.Core.Utils;

namespace Releaser.Core.EntityStore
{
	/// <summary>
	/// Saves entities to files.
	/// </summary>
	public class FileEntityStore : IEntityStore
	{
		private const string c_extention = ".dat";
		private readonly string m_path;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public FileEntityStore(string path)
		{
			m_path = path;
		}

		/// <summary>
		/// Reads object by specified ID.
		/// </summary>
		public T Read<T>(string id)
		{
			var folderName = typeof(T).Name;
			var fileName = "{0}{1}".F(id, c_extention);
			var filePath = Path.Combine(m_path, folderName, fileName);
			if (!File.Exists(filePath))
				return default(T);

			return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
		}

		/// <summary>
		/// Writes specified object.
		/// </summary>
		public void Write(AggregateRoot entity)
		{
			var folderName = entity.GetType().Name;
			var folderPath = Path.Combine(m_path, folderName);
			if (!Directory.Exists(folderPath))
				Directory.CreateDirectory(folderPath);

			var fileName = "{0}{1}".F(entity.Id, c_extention);
			var filePath = Path.Combine(folderPath, fileName);

			File.WriteAllText(filePath, JsonConvert.SerializeObject(entity));
		}
	}
}