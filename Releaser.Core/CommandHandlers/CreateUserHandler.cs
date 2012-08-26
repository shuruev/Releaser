using System.Collections.Generic;
using Releaser.Core.Commands;
using Releaser.Core.Entities;
using Releaser.Core.EntityStore;
using Releaser.Core.Events;

namespace Releaser.Core.CommandHandlers
{
	/// <summary>
	/// Handles create user command.
	/// </summary>
	public class CreateUserHandler : BaseCommandHandler<CreateUser>
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CreateUserHandler(IEntityStore store)
			: base(store)
		{
		}

		/// <summary>
		/// Executes specified command.
		/// </summary>
		protected override List<BaseEvent> ExecuteInternal(CreateUser command)
		{
			var user = new User(
				command.UserCode,
				command.UserLogin,
				command.UserName);

			m_store.Write(user);

			return user.GetChanges();
		}
	}
}