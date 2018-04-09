using System;
using System.Collections.Generic;
using System.Text;

namespace ePixelation.Scaffold.Composition
{
	public class ContainerOptions
	{
		public ContainerOptions()
		{
			Container = new ContainerSettings();
			Logging = new LogSettings();
			Database = new DatabaseSettings();
		}

		public ContainerSettings Container { get; set; }

		public LogSettings Logging { get; set; }

		public DatabaseSettings Database { get; set; }

		public class ContainerSettings
		{
			
		}

		public class LogSettings
		{
			public bool LogRequestsAndResponses { get; set; }
		}

		public class DatabaseSettings
		{
			public string DataConnectionString { get; set; }
		}

	}
}
