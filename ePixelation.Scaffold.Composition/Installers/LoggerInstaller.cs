using Autofac;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ePixelation.Scaffold.Composition.Installers
{
	public class LoggerInstaller
	{
		private readonly ContainerOptions _options;

		public LoggerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var logger = LogManager.GetLogger("ePixelation.Scaffold.Logger");

			builder
				.RegisterInstance<ILogger>(logger)
				.SingleInstance();
		}
	}
}
