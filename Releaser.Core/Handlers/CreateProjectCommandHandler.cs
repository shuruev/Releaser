using Releaser.Core.Commands;
using Releaser.Core.MongoDb;
using Releaser.Core.Results;

namespace Releaser.Core.Handlers
{
	/// <summary>
	/// Handler for create project command.
	/// </summary>
	public class CreateProjectCommandHandler : BaseCommandHandler<CreateProjectCommand, EmptyResult>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CreateProjectCommandHandler(IMongoDb mongoDb) : base(mongoDb)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override EmptyResult ExecuteInternal(CreateProjectCommand command)
		{
			m_mongoDb.SaveEntity(command.Project);

			return new EmptyResult();
		}
	}
}
