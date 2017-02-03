using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    public class DummyController : Controller
    {
		private CitiesDbContext _ctx;

		public DummyController(CitiesDbContext ctx)
		{
			_ctx = ctx;
		}

		[HttpGet]
		[Route("api/testdatabase")]
		public IActionResult TestDatabase()
		{
			return Ok();
		}
	}
}