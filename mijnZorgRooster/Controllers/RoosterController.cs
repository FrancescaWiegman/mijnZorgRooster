using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Services;
using mijnZorgRooster.DAL.Repositories;

namespace mijnZorgRooster.Controllers
{
    public class RoosterController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IRoosterRepository _roosterRepository;
        private readonly IDienstRepository _dienstRepository;

		public RoosterController(IUnitOfWork unitOfWork, IRoosterRepository roosterRepository, IDienstRepository dienstRepository)
		{
			_unitOfWork = unitOfWork;
            _roosterRepository = roosterRepository;
            _dienstRepository = dienstRepository;
		}

		// GET: Rooster
		public async Task<IActionResult> Index()
		{
			return View(await _roosterRepository.GetAsync());
		}

		// GET: Rooster/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			RoosterDTO roosterDTO = null;

			if (id.HasValue)
			{
                roosterDTO = await _roosterRepository.GetByIdAsync(id.Value);
			}
			else
			{
				return NotFound();
			}

			return View(roosterDTO);
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
				_roosterRepository.Insert(rooster);
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
			RoosterMetDienstProfielenDTO roosterDTO = await _roosterRepository.GetRoosterMetDienstProfielenDto(id.Value);

			if (roosterDTO == null)
			{
				return NotFound();
			}

            TempData["MinInvoerJaar"] = DateTime.UtcNow.Year;

			return View(roosterDTO);
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
                    _roosterRepository.Update(rooster);

                    var oudRooster = await _roosterRepository.GetRoosterMetDienstProfielenDto(id);
                    var lijstMetRoosterDienstProfielIds = oudRooster.RoosterDienstProfielen.Select(rdp => rdp.DienstProfielId).Distinct().ToList();

                    if (!lijstMetRoosterDienstProfielIds.SequenceEqual(selectedDienstProfielen)) //check of de dienstprofielen van een rooster zijn veranderd
                    {
                        await _roosterRepository.UpdateRoosterDienstProfielen(id, selectedDienstProfielen);

                        //Nu moeten we diensten die aan het rooster hangen nog updaten
                        List<Dienst> nieuweDiensten = _dienstRepository.GenereerDiensten(id, selectedDienstProfielen);
                        rooster.Diensten = nieuweDiensten;
                        _roosterRepository.Update(rooster);
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
			RoosterDTO roosterDTO = null;
			if (id.HasValue)
			{
                roosterDTO = await _roosterRepository.GetByIdAsync(id.Value);
			}
			else
			{
				return NotFound();
			}

			if (roosterDTO == null)
			{
				return NotFound();
			}

			return View(roosterDTO);
		}

		// POST: Rooster/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			_roosterRepository.Delete(id);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> RoosterExists(int id)
		{
			var res = await _roosterRepository.GetAsync();
			return res.Any(r => r.RoosterID == id);
		}
	}
}
