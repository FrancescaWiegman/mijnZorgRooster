using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Services;
using mijnZorgRooster.Utilities;

namespace mijnZorgRooster.Controllers
{
    public class DienstController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoosterService _roosterService;

		public DienstController(IRoosterService roosterService, IUnitOfWork unitOfWork)
		{
			_roosterService = roosterService;
			_unitOfWork = unitOfWork;
		}

		// GET: Dienst
		public async Task<IActionResult> Index()
        {
			return View(await _unitOfWork.DienstRepository.GetAsync());
		}

		// GET: Dienst/Create
		public async Task<IActionResult> Create(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			RoosterMetDienstProfielenDto roosterDto = await _unitOfWork.RoosterRepository.GetRoosterMetDienstProfielenDto(id);
			if (roosterDto == null)
			{
				return NotFound();
			}

			if (_roosterService.telAantalGeselecteerdeDienstProfielen(roosterDto) < 1)
			{
				TempData["RedirectToRoosterEdit"] = "Kies eerst 1 of meer profielen";
				return RedirectToAction("Edit", "Rooster", new { id = roosterDto.RoosterID});
			}
			else
			{
				// logica waarbij gekeken wordt hoeveel dagen er in het rooster zit, hoeveel en welke dienstprofielen opgehaald moeten worden, en daarna voor elk dienstprofiel en elke dag
				// van de maand een dienst aangemaakt wordt.
				return View();
			}
		}
	}
}