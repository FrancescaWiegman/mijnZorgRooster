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

namespace mijnZorgRooster.Controllers
{
	public class DienstController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoosterService _roosterService;
		private readonly IDienstService _dienstService;

		public DienstController(IRoosterService roosterService, IDienstService dienstService, IUnitOfWork unitOfWork)
		{
			_roosterService = roosterService;
			_dienstService = dienstService;
			_unitOfWork = unitOfWork;
		}

		// GET: Dienst
		public async Task<IActionResult> Index()
		{
			IList<Dienst> dienstList = await _unitOfWork.DienstRepository.GetAsync();
			List<DienstDto> dienstDtoList = new List<DienstDto>();
			DienstDto dienstDto = new DienstDto();

			foreach (var d in dienstList)
			{
				dienstDto = await _unitOfWork.DienstRepository.GetDienstDto(d.DienstID);
				// TODO: rooster nog aanhangen?
				dienstDtoList.Add(dienstDto);
			}
			return View(dienstDtoList);
		}

        public async Task<IActionResult> Details(int? id)
        {
            DienstDto dienst = null;

            if (id.HasValue)
            {
                dienst = await _unitOfWork.DienstRepository.GetDienstDto(id.Value);
            }
            else
            {
                return NotFound();
            }

            return View(dienst);
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
				return RedirectToAction("Edit", "Rooster", new { id = roosterDto.RoosterID });
			}

			return View(roosterDto);

		}

		// GET: Rooster/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(int roosterID)
		{
			if (ModelState.IsValid)
			{
				RoosterMetDienstProfielenDto roosterDto = await _unitOfWork.RoosterRepository.GetRoosterMetDienstProfielenDto(roosterID);
				List<DienstProfiel> dienstProfielList = await _unitOfWork.DienstProfielRepository.GetAsync();
				ICollection<Dienst> nieuweDiensten = _dienstService.GenereerDiensten(roosterDto, dienstProfielList);

				//TODO: Uitzoeken waarom de nieuwe diensten niet worden gehangen aan het rooster

				Rooster roosterUpdate = new Rooster
				{
					RoosterID = roosterDto.RoosterID,
					Jaar = roosterDto.Jaar,
					Maand = roosterDto.Maand,
					//AanmaakDatum = roosterDto.AanmaakDatum,
					//LaatsteWijzigingsDatum = roosterDto.LaatsteWijzigingsDatum,
					IsGevalideerd = roosterDto.IsGevalideerd,
                    Diensten = new List<Dienst>()
				};

                foreach (var dienst in nieuweDiensten)
                {
                    _unitOfWork.DienstRepository.Insert(dienst);
                    roosterUpdate.Diensten.Add(dienst);
                }

                _unitOfWork.RoosterRepository.Update(roosterUpdate);
                await _unitOfWork.SaveAsync();
            }
			return RedirectToAction(nameof(Index));
		}
	}
}