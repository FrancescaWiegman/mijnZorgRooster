using System;
using System.Collections;
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
    public class RoosterController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoosterService _roosterService;

		public RoosterController(IRoosterService roosterService, IUnitOfWork unitOfWork)
		{
			_roosterService = roosterService;
			_unitOfWork = unitOfWork;
		}

		// GET: Rooster
		public async Task<IActionResult> Index()
		{
			var roostersDto = from rooster in await _unitOfWork.RoosterRepository.GetAsync()
							  select new RoosterBasisDto(rooster);
			List<RoosterMetDienstProfielenDto> RoostersMetDienstProfielen = new List<RoosterMetDienstProfielenDto>();
			var roosters = await _unitOfWork.RoosterRepository.GetAsync();

			foreach (var r in roosters)
			{
				RoosterMetDienstProfielenDto roosterDto = await _unitOfWork.RoosterRepository.GetRoosterMetDienstProfielenDto(r.RoosterID);
				RoostersMetDienstProfielen.Add(roosterDto);
			}
			ViewBag.DPHeader = "DienstProfielen";
			ViewBag.DPValue = RoostersMetDienstProfielen;
			return View(roostersDto);
		}

		// GET: Rooster/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			Rooster rooster = null;

			if (id.HasValue)
			{
				rooster = await _unitOfWork.RoosterRepository.GetByIdAsync(id.Value);
			}
			else
			{
				return NotFound();
			}

			RoosterDetailDto roosterDetails = new RoosterDetailDto(rooster);
			roosterDetails.AantalDagen = _roosterService.geefAantalDagen(rooster.Maand, rooster.Jaar);
			roosterDetails.StartDatum = _roosterService.genereerStartDatum(rooster.Maand, rooster.Jaar);
			roosterDetails.EindDatum = _roosterService.genereerEindDatum(rooster.Maand, rooster.Jaar);
			return View(roosterDetails);
		}

		// GET: Rooster/Create
		public IActionResult Create()
		{
			ViewBag.MinInvoerJaar = _roosterService.geefToelaatbaarJaarInvoer();
			return View();
		}

		// POST: Rooster/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("RoosterID,Jaar,Maand")] Rooster rooster)
		{
			if (ModelState.IsValid)
			{
				rooster.AanmaakDatum = _roosterService.geefDatumVanVandaag();
				rooster.LaatsteWijzigingsDatum = _roosterService.geefDatumVanVandaag();
				rooster.IsGevalideerd = false;
				_unitOfWork.RoosterRepository.Insert(rooster);
				await _unitOfWork.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(rooster);
		}

		// GET: Rooster/Edit/5
		public async Task<IActionResult> Edit(int? id)
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
			ViewBag.MinInvoerJaar = _roosterService.geefToelaatbaarJaarInvoer();
			return View(roosterDto);
		}

		// POST: Rooster/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("RoosterID,AanmaakDatum,Jaar,Maand,IsGevalideerd")] Rooster rooster, List<int> SelectedDienstProfielen)
		{
			if (id != rooster.RoosterID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					rooster.LaatsteWijzigingsDatum = _roosterService.geefDatumVanVandaag();
					_unitOfWork.RoosterRepository.Update(rooster);

					var oudRooster = await _unitOfWork.RoosterRepository.GetRoosterMetDienstProfielen(rooster.RoosterID);
					var lijstMetRoosterDienstProfielIds = oudRooster.RoosterDienstProfielen.Select(d => d.DienstProfielId).ToList();
					if (!lijstMetRoosterDienstProfielIds.SequenceEqual(SelectedDienstProfielen)) //check of de dienstprofielen van een rooster zijn veranderd
						await _unitOfWork.RoosterRepository.UpdateRoosterDienstProfielen(oudRooster.RoosterID, SelectedDienstProfielen);

					_unitOfWork.Save();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await RoosterExists(rooster.RoosterID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(rooster);
		}

		// GET: Rooster/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			Rooster rooster = null;
			if (id.HasValue)
			{
				rooster = await _unitOfWork.RoosterRepository.GetByIdAsync(id.Value);
			}
			else
			{
				return NotFound();
			}

			if (rooster == null)
			{
				return NotFound();
			}

			RoosterBasisDto roosterDto = new RoosterBasisDto(rooster);

			return View(roosterDto);
		}

		// POST: Rooster/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var rooster = await _unitOfWork.RoosterRepository.GetByIdAsync(id);
			_unitOfWork.RoosterRepository.Delete(rooster);
			await _unitOfWork.SaveAsync();
			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> RoosterExists(int id)
		{
			var res = await _unitOfWork.RoosterRepository.GetAsync();
			return res.Any(r => r.RoosterID == id);
		}
	}
}
