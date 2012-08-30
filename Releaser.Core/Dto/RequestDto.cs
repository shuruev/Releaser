namespace Releaser.Core.Dto
{
	/// <summary>
	/// Data transfer object for command.
	/// </summary>
	public class RequestDto
	{
		/// <summary>
		/// Gets command type string.
		/// </summary>
		public const string CommandType = "command";

		/// <summary>
		/// Gets query type string.
		/// </summary>
		public const string QueryType = "query";

		/// <summary>
		/// Gets or sets type of command (Command / Query).
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets JSON string with command.
		/// </summary>
		public string Json { get; set; }
	}
}
