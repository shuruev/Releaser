namespace Releaser.Core.Ioc
{
	/// <summary>
	/// Interface for resolving types.
	/// </summary>
	public interface IResolver
	{
		/// <summary>
		/// Returns object of specified type.
		/// </summary>
		T Resolve<T>();
	}
}
