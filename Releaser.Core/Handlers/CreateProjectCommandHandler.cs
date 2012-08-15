using Releaser.Core.Commands;
using Releaser.Core.Results;

namespace Releaser.Core.Handlers
{
	/// <summary>
	/// Handler for create project command.
	/// </summary>
	public class CreateProjectCommandHandler : BaseCommandHandler<CreateProjectCommand, EmptyResult>
	{
		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override EmptyResult ExecuteInternal(CreateProjectCommand command)
		{
			return new EmptyResult();
		}
	}
}
