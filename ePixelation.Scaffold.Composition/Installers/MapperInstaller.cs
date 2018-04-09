using Autofac;
using AutoMapper;

namespace ePixelation.Scaffold.Composition.Installers
{
	public class MapperInstaller
	{
		private readonly ContainerOptions _options;

		public MapperInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var configuration = new MapperConfiguration(cfg => {
				cfg.CreateMissingTypeMaps = true;
			});

			var mapper = new Mapper(configuration);

			builder
				.RegisterInstance<IMapper>(mapper)
				.SingleInstance();
		}
	}
}
