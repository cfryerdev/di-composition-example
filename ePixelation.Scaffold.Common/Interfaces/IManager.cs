using AutoMapper;
using ePixelation.Scaffold.Common.Mapping;
using NLog;
using System.Data;

namespace ePixelation.Scaffold.Common.Interfaces
{
	public interface IManager
	{
		IMapper Mapper { get; }
		ILogger Logger { get; }
	}
}
