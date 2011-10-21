using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Releaser.Core.Entities
{
	/// <summary>
	/// Entity project.
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Gets or sets entity identifier.
		/// </summary>
		[BsonId]
		public ObjectId Id { get; set; }

		/// <summary>
		/// Gets or sets project name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets project display name.
		/// </summary>
		public string DisplayName { get; set; }

		/// <summary>
		/// Gets or sets path to project version.
		/// </summary>
		public string Path { get; set; }
	}
}
