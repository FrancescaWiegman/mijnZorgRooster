using Microsoft.AspNetCore.Mvc;
using mijnZorgRooster.DAL;

namespace mijnZorgRooster.Controllers
{
    public class RoosterController : Controller
	{
        private readonly IUnitOfWork _unitOfWork;

        public RoosterController(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}

		public IActionResult Rooster()
		{
			return View(); 
		}
	}
}
