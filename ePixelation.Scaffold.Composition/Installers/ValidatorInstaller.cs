using Autofac;
using ePixelation.Scaffold.Domain;
using ePixelation.Scaffold.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ePixelation.Scaffold.Composition.Installers
{
	public class ValidatorInstaller
	{
		private readonly ContainerOptions _options;

		public ValidatorInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var managerAssembly = typeof(Init).GetTypeInfo().Assembly;

			builder
				.RegisterAssemblyTypes(managerAssembly)
				.Where(t => typeof(IValidateSaveRule<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();

			builder
				.RegisterAssemblyTypes(managerAssembly)
				.Where(t => typeof(IValidateDeleteRule<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
