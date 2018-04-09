using Autofac;
using ePixelation.Scaffold.Common.Base;
using ePixelation.Scaffold.Domain;
using System.Reflection;
using ePixelation.Scaffold.Domain.Base;

namespace ePixelation.Scaffold.Composition.Installers
{
	public class ManagerInstaller
	{
		private readonly ContainerOptions _options;

		public ManagerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var managerAssembly = typeof(Init).GetTypeInfo().Assembly;
			
			builder
				.RegisterAssemblyTypes(managerAssembly)
				.Where(t => typeof(BaseManager).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
