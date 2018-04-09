using Autofac;
using Autofac.Core;
using ePixelation.Scaffold.Composition.Installers;
using System;

namespace ePixelation.Scaffold.Composition
{
	public class ContainerInstaller
	{
		private readonly ContainerOptions _options;

		public ContainerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public ContainerBuilder Install()
		{
			var builder = new ContainerBuilder();

			new LoggerInstaller(_options).Install(builder);
			new IDbConnectionInstaller(_options).Install(builder);
			new ValidatorInstaller(_options).Install(builder);
			new MapperInstaller(_options).Install(builder);
			new ManagerInstaller(_options).Install(builder);

			return builder;
		}
	}
}
