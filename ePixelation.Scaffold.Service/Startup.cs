using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using ePixelation.Scaffold.Composition;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace ePixelation.Scaffold.Service
{
	public class Startup
	{
		public IContainer ApplicationContainer { get; private set; }
		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
					.SetBasePath(Path.Combine(env.ContentRootPath, @"Configuration"))
					.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
					.AddJsonFile($"apisettings.json", optional: true, reloadOnChange: true)
					.AddJsonFile($"apisettings.{env.EnvironmentName}.json", optional: true)
					.AddEnvironmentVariables();
			Configuration = builder.Build();
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddOptions();
			services.Configure<ContainerOptions>(Configuration);
			var settings = Configuration.Get<ContainerOptions>();
			
			services
				.AddMvc()
				.AddJsonOptions(jsonOptions =>
				{
					jsonOptions.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
				});

			var corsBuilder = new CorsPolicyBuilder();
			corsBuilder.AllowAnyHeader();
			corsBuilder.AllowAnyMethod();
			corsBuilder.AllowAnyOrigin();
			corsBuilder.WithOrigins(GetConfigArray("CORS:Origins").ToArray());
			corsBuilder.AllowCredentials();
			services.AddCors(opts => { opts.AddPolicy("DefaultCorsPolicy", corsBuilder.Build()); });

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "ePixelation.Scaffold", Version = "v1" });
			});

			// *********************************************
			// INSTALL THE CONTAINER
			// *********************************************
			var installer = new ContainerInstaller(settings);
			var builder = installer.Install();
			builder.Populate(services);
			ApplicationContainer = builder.Build();

			return new AutofacServiceProvider(ApplicationContainer);
		}
		
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifeTime)
		{
			loggerFactory.AddNLog();
			loggerFactory.ConfigureNLog("nlog.config");
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "ePixelation.Scaffold");
			});
			app.UseMvc();
			appLifeTime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
		}

		private List<String> GetConfigArray(string name)
		{
			var corsList = new List<String>();
			foreach (var item in Configuration.GetSection(name).AsEnumerable())
			{
				if (!string.IsNullOrWhiteSpace(item.Value))
				{
					corsList.Add(item.Value);
				}
			}
			return corsList;
		}
	}
}
