using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mijnZorgRooster.DAL;

namespace mijnZorgRooster.Controllers
{
	public class RoosterController : Controller
	{
		private readonly ZorginstellingDbContext _context;

		public RoosterController(ZorginstellingDbContext context)
		{
			_context = context;
		}

		public IActionResult Rooster()
		{
			return View(); 
		}
	}
}
