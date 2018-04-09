using AutoMapper;
using ePixelation.Scaffold.Common.Interfaces;
using System.Data;
using System;
using NLog;

namespace ePixelation.Scaffold.Domain.Base
{
	public abstract class BaseManager : IManager
	{
		public BaseManager(IMapper mapper, ILogger logger)
		{
			Mapper = mapper;
			Logger = logger;
		}
		
		public IMapper Mapper { get; set; }
		public ILogger Logger { get; set; }
	}
}
