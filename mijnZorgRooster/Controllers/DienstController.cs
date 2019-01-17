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

		// GET: Dienst/RoosterIndex
		public async Task<IActionResult> RoosterIndex(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			RoosterMetDienstProfielenDto roostersDto = await _unitOfWork.RoosterRepository.GetRoosterMetDienstProfielenDto(id);
			if (roostersDto == null)
			{
				return NotFound();
			}

			List<DienstDto> diensten = new List<DienstDto>();
			List<DienstProfiel> dienstProfielList = await _unitOfWork.DienstProfielRepository.GetAsync();

			foreach (var profielID in roostersDto.SelectedDienstProfielen)
			{
				foreach (var profiel in dienstProfielList)
				{
					if (profielID == profiel.DienstProfielID)
					{
						var profielDto = new DienstProfielDto(profiel);
						
						
						
						
						
						//diensten.Add(profielDto);
					}
				}
			}


			// dit stuk telt niet mee


			//roostersDto.SelectedDienstProfielen;



			//foreach(var r in roostersDto){
			//}


			//var roostersDto = from rooster in await _unitOfWork.RoosterRepository.GetAsync()
			//				  select new RoosterBasisDto(rooster);
			//List<RoosterMetDienstProfielenDto> RoostersMetDienstProfielen = new List<RoosterMetDienstProfielenDto>();
			//var roosters = await _unitOfWork.RoosterRepository.GetAsync();

			//foreach (var r in roosters)
			//{
			//	RoosterMetDienstProfielenDto roosterDto = await _unitOfWork.RoosterRepository.GetRoosterMetDienstProfielenDto(r.RoosterID);
			//	RoostersMetDienstProfielen.Add(roosterDto);
			//}




			return View(diensten);
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
			else
			{
				roosterDto.AantalDagen = _roosterService.geefAantalDagen(roosterDto.Maand, roosterDto.Jaar);
				roosterDto.StartDatum = _roosterService.genereerStartDatum(roosterDto.Maand, roosterDto.Jaar);
				roosterDto.EindDatum = _roosterService.genereerEindDatum(roosterDto.Maand, roosterDto.Jaar);
				return View(roosterDto);
			}
		}

		// GET: Rooster/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("RoosterID,Diensten")] Rooster rooster)
		{
			if (ModelState.IsValid)
			{
				RoosterMetDienstProfielenDto roosterDto = await _unitOfWork.RoosterRepository.GetRoosterMetDienstProfielenDto(rooster.RoosterID);
				roosterDto.StartDatum = _roosterService.genereerStartDatum(roosterDto.Maand, roosterDto.Jaar);
				roosterDto.EindDatum = _roosterService.genereerEindDatum(roosterDto.Maand, roosterDto.Jaar);
				List<DienstProfiel> dienstProfielList = await _unitOfWork.DienstProfielRepository.GetAsync();
				ICollection<Dienst> nieuweDiensten = _dienstService.GenereerDiensten(roosterDto, dienstProfielList);

				//TODO: Uitzoeken waarom de nieuwe diensten niet worden gehangen aan het rooster

				Rooster roosterUpdate = new Rooster
				{
					RoosterID = roosterDto.RoosterID,
					Jaar = roosterDto.Jaar,
					Maand = roosterDto.Maand,
					AanmaakDatum = roosterDto.AanmaakDatum,
					LaatsteWijzigingsDatum = roosterDto.LaatsteWijzigingsDatum,
					IsGevalideerd = roosterDto.IsGevalideerd,
					Diensten = getDienstenOrEmptyList(roosterDto)
				};

				foreach (var dienst in nieuweDiensten)
				{
					_unitOfWork.DienstRepository.Insert(dienst);
					roosterUpdate.Diensten.Add(dienst);
					_unitOfWork.RoosterRepository.Update(roosterUpdate);
					await _unitOfWork.SaveAsync();
				}
			}
			return RedirectToAction(nameof(Index));
		}

		private ICollection<Dienst> getDienstenOrEmptyList(RoosterMetDienstProfielenDto roosterDto)
		{
			if (roosterDto.Diensten == null)
			{
				return new List<Dienst>();
			}
			return roosterDto.Diensten;
		}
	}
}