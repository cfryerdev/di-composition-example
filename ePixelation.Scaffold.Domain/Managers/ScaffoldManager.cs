using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Data;
using NLog;
using ePixelation.Scaffold.Domain.Base;

namespace ePixelation.Scaffold.Domain.Managers
{
	public class ScaffoldManager : BaseManager
	{
		private IDbConnection Connection;

		public ScaffoldManager(IDbConnection connection, IMapper mapper, ILogger logger) : base(mapper, logger)
		{
			Connection = connection;
		}

		public object Test()
		{
			return new { Message = "Hello World" };
		}
	}
}
