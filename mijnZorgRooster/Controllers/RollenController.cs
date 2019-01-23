using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.DAL.Repositories;

namespace mijnZorgRooster.Controllers
{
    public class RollenController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRolRepository _rolRepository;
            
        public RollenController(IUnitOfWork unitOfWork, IRolRepository rolRepository)
        {
            _unitOfWork = unitOfWork;
            _rolRepository = rolRepository;
        }

        // GET: Rollen
        public async Task<IActionResult> Index()
        {
            return View(await _rolRepository.GetAsync());
        }

        // GET: Rollen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            RolDTO rolDTO = null;
    
            if (id.HasValue)
            {
                rolDTO = await _rolRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }

            return View(rolDTO);
        }

        // GET: Rol/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RolID,Naam")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                _rolRepository.Insert(rol);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        //// GET: Rol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RolDTO rolDTO = await _rolRepository.GetByIdAsync(id.Value);

            if (rolDTO == null)
            {
                return NotFound();
            }

            return View(rolDTO);
        }

        //// POST: Rol/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RolID,Naam")] Rol rol)
        {
            if (id != rol.RolID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _rolRepository.Update(rol);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RolExists(rol.RolID))
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

            RolDTO rolDto = new RolDTO
            {
                RolID = rol.RolID,
                Naam = rol.Naam
            };

            return View(rolDto);
        }

        //// GET: Rol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            RolDTO rolDTO = null;
            if (id.HasValue)
            {
                rolDTO = await _rolRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }

            if (rolDTO == null)
            {
                return NotFound();
            }

            return View(rolDTO);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _rolRepository.Delete(id);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RolExists(int id)
        {
            var res = await _rolRepository.GetAsync();
            return res.Any(m => m.RolID == id);
        }
    }
}
