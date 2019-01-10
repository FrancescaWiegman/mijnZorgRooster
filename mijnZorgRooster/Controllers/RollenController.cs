using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Models.Entities;
using System.Linq;
using System.Threading.Tasks;


namespace mijnZorgRooster.Controllers
{
    public class RollenController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
            
        public RollenController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Rollen
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.RolRepository.GetAsync());
        }

        // GET: Rollen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Rol rol = null;
    
            if (id.HasValue)
            {
                rol = await _unitOfWork.RolRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }
           
            return View(rol);
        }

        // GET: Rol/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RolID,Naam")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RolRepository.Insert(rol);
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

            var rol = await _unitOfWork.RolRepository.GetByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        //// POST: Rol/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _unitOfWork.RolRepository.Update(rol);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MedewerkerExists(rol.RolID))
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
            return View(rol);
        }

        //// GET: Rol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Rol rol = null;
            if (id.HasValue)
            {
                rol = await _unitOfWork.RolRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }

            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rol = await _unitOfWork.RolRepository.GetByIdAsync(id);
            _unitOfWork.RolRepository.Delete(rol);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MedewerkerExists(int id)
        {
            var res = await _unitOfWork.MedewerkerRepository.GetAsync();
            return res.Any(m => m.MedewerkerID == id);
        }
    }
}
