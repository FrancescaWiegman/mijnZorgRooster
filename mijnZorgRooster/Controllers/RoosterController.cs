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

		public RoosterController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: Rooster
		public async Task<IActionResult> Index()
		{
			return View(await _unitOfWork.RoosterRepository.GetRoosters());
		}

		// GET: Rooster/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			RoosterDetailDto rooster = null;

			if (id.HasValue)
			{
                rooster = await _unitOfWork.RoosterRepository.GetRooster(id.Value);
			}
			else
			{
				return NotFound();
			}

			return View(rooster);
		}

		// GET: Rooster/Create
		public IActionResult Create()
		{
            TempData["MinInvoerJaar"] = DateTime.UtcNow.Year;
            return View();
		}

		// POST: Rooster/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("RoosterID,Jaar,Maand")] Rooster rooster)
		{
			if (ModelState.IsValid)
			{
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

            TempData["MinInvoerJaar"] = DateTime.UtcNow.Year;

            if (TempData.ContainsKey("RedirectToRoosterEdit"))
			{
				roosterDto.EditViewErrorMessage = TempData["RedirectToRoosterEdit"].ToString();
				return View(roosterDto);
			}
			else
			{
				return View(roosterDto);
			}
		}

		// POST: Rooster/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("RoosterID,AanmaakDatum,Jaar,Maand,IsGevalideerd")] Rooster rooster, List<int> selectedDienstProfielen)
		{
			if (id != rooster.RoosterID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
                    _unitOfWork.RoosterRepository.Update(rooster);

                    var oudRooster = await _unitOfWork.RoosterRepository.GetRoosterMetDienstProfielenDto(rooster.RoosterID);
					var lijstMetRoosterDienstProfielIds = oudRooster.Diensten.Select(d => d.DienstProfiel.DienstProfielID).Distinct().ToList();
					if (!lijstMetRoosterDienstProfielIds.SequenceEqual(selectedDienstProfielen)) //check of de dienstprofielen van een rooster zijn veranderd
                    {
                        await _unitOfWork.RoosterRepository.UpdateRoosterDienstProfielen(oudRooster.RoosterID, selectedDienstProfielen);

                        //Nu moeten we diensten die aan het rooster hangen nog updaten
                        ICollection<Dienst> nieuweDiensten = _unitOfWork.DienstRepository.GenereerDiensten(oudRooster, selectedDienstProfielen);
                        rooster.Diensten = nieuweDiensten;
                        _unitOfWork.RoosterRepository.Update(rooster);
                    }

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
