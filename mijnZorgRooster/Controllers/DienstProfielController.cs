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
    public class DienstProfielController : Controller
    {

		private readonly IUnitOfWork _unitOfWork;

		public DienstProfielController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: DienstProfiel
		public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.DienstProfielRepository.GetAsync());
        }

		// GET: DienstProfiel/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			DienstProfiel dienstProfiel = null;

			if (id.HasValue)
			{
				dienstProfiel = await _unitOfWork.DienstProfielRepository.GetByIdAsync(id.Value);
			}
			else
			{
				return NotFound();
			}


			DienstProfielDetailDto dienstProfielDetails = new DienstProfielDetailDto(dienstProfiel);
			return View(dienstProfielDetails);
		}

		// GET: DienstProfiel/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: DienstProfiel/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("DienstProfielID,Beschrijving,Begintijd,Eindtijd,MinimaleBezetting")] DienstProfiel dienstProfiel)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.DienstProfielRepository.Insert(dienstProfiel);
				await _unitOfWork.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(dienstProfiel);
		}

		// GET: DienstProfiel/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var dienstProfiel = await _unitOfWork.DienstProfielRepository.GetByIdAsync(id);
			if (dienstProfiel == null)
			{
				return NotFound();
			}
			return View(dienstProfiel);
		}

		// POST: DienstProfiel/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("DienstProfielID,Beschrijving,Begintijd,Eindtijd,MinimaleBezetting")] DienstProfiel dienstProfiel)
		{
			if (id != dienstProfiel.DienstProfielID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_unitOfWork.DienstProfielRepository.Update(dienstProfiel);
					await _unitOfWork.SaveAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await DienstProfielExists(dienstProfiel.DienstProfielID))
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
			return View(dienstProfiel);
		}

		// GET: DienstProfiel/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			DienstProfiel dienstProfiel = null;
			if (id.HasValue)
			{
				dienstProfiel = await _unitOfWork.DienstProfielRepository.GetByIdAsync(id.Value);
			}
			else
			{
				return NotFound();
			}

			if (dienstProfiel == null)
			{
				return NotFound();
			}

			return View(dienstProfiel);
		}

		// POST: DienstProfiel/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var dienstProfiel = await _unitOfWork.DienstProfielRepository.GetByIdAsync(id);
			_unitOfWork.DienstProfielRepository.Delete(dienstProfiel);
			await _unitOfWork.SaveAsync();
			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> DienstProfielExists(int id)
		{
			var res = await _unitOfWork.DienstProfielRepository.GetAsync();
			return res.Any(d => d.DienstProfielID == id);
		}
	}
}