using Autofac;

namespace Releaser.Core.Ioc
{
	/// <summary>
	/// Resolver which uses Autofac IOC container.
	/// </summary>
	public class AutofacResolver : IResolver
	{
		private readonly IContainer m_container;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public AutofacResolver(IContainer container)
		{
			m_container = container;
		}

		/// <summary>
		/// Returns object of specified type.
		/// </summary>
		public T Resolve<T>()
		{
			return m_container.Resolve<T>();
		}
	}
}
