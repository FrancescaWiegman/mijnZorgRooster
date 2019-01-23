using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.DAL.Repositories;
using mijnZorgRooster.Models;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Controllers
{
    public class DienstProfielController : Controller
    {

		private readonly IUnitOfWork _unitOfWork;
        private readonly IDienstProfielRepository _dienstProfielRepository;

		public DienstProfielController(IUnitOfWork unitOfWork, IDienstProfielRepository dienstProfielRepository)
		{
			_unitOfWork = unitOfWork;
            _dienstProfielRepository = dienstProfielRepository;
		}

		// GET: DienstProfiel
		public async Task<IActionResult> Index()
        {
			return View(await _dienstProfielRepository.GetAsync());
		}

		// GET: DienstProfiel/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			DienstProfielDTO dienstProfielDTO = null;

			if (id.HasValue)
			{
                dienstProfielDTO = await _dienstProfielRepository.GetByIdAsync(id.Value);
			}
			else
			{
				return NotFound();
			}

			return View(dienstProfielDTO);
		}

		// GET: DienstProfiel/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: DienstProfiel/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("DienstProfielID,Beschrijving,Begintijd,Eindtijd,MinimaleBezetting")] DienstProfiel dienstProfiel)
		{
			if (ModelState.IsValid)
			{
				_dienstProfielRepository.Insert(dienstProfiel);
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

            DienstProfielDTO dienstProfielDTO = await _dienstProfielRepository.GetByIdAsync(id.Value);
			if (dienstProfielDTO == null)
			{
				return NotFound();
			}

			return View(dienstProfielDTO);
		}

		// POST: DienstProfiel/Edit/5
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
					_dienstProfielRepository.Update(dienstProfiel);
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
			DienstProfielDTO dienstProfielDTO = null;

			if (id.HasValue)
			{
                dienstProfielDTO = await _dienstProfielRepository.GetByIdAsync(id.Value);
			}
			else
			{
				return NotFound();
			}

			if (dienstProfielDTO == null)
			{
				return NotFound();
			}

			return View(dienstProfielDTO);
		}

		// POST: DienstProfiel/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			_dienstProfielRepository.Delete(id);
			await _unitOfWork.SaveAsync();
			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> DienstProfielExists(int id)
		{
			var res = await _dienstProfielRepository.GetAsync();
			return res.Any(d => d.DienstProfielID == id);
		}
	}
}