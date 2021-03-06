﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ePixelation.Scaffold.Composition.Installers
{
	public class IDbConnectionInstaller
	{
		private readonly ContainerOptions _options;

		public IDbConnectionInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var connection = new SqlConnection(_options.Database.DataConnectionString);
			connection.Open();

			builder
				.RegisterInstance<IDbConnection>(connection)
				.SingleInstance();
		}
	}
}
