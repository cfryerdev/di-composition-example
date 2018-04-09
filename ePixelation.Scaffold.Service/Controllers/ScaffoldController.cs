using ePixelation.Scaffold.Domain.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ePixelation.Scaffold.Service.Controllers
{
	[Route("api/[controller]")]
	public class ScaffoldController
	{
		private readonly ScaffoldManager _manager;

		public ScaffoldController(ScaffoldManager manager)
		{
			_manager = manager;
		}

		[HttpGet, Route("Test")]
		public object Test()
		{
			return _manager.Test();
		}

	}
}
