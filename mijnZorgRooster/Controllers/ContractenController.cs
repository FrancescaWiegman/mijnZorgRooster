using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using mijnZorgRooster.Services;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Controllers
{
    public class ContractenController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalculationsService _calculationService;

        public int MedewerkerID { get; private set; }

        public ContractenController(ICalculationsService calculationService, IUnitOfWork unitOfWork)
        {
            _calculationService = calculationService;
            _unitOfWork = unitOfWork; ;
        }

        // GET: Contracten
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.ContractRepository.GetAsync());
        }

        // GET: Contracten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Contract contract = null;

            if (id.HasValue)
            {
                contract = await _unitOfWork.ContractRepository.GetByIdAsync(id.Value);
            }
            else


            {
                return NotFound();
            }
            ContractDetailDto contractDetails = new ContractDetailDto()
            {
                BerekenParttimePercentage = _calculationService.BerekenParttimePercentage(contract.Medewerker.MedewerkerID)

            };

            return View(contract);
        }

        // GET: Contracten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contracten/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeginDatum,Einddatum,ContractUren,VerlofDagenPerJaar,ParttimePercentage")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ContractRepository.Insert(contract);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contract);
        }

        // GET: Contracten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _unitOfWork.ContractRepository.GetByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return View(contract);
        }

        // POST: Contracten/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeginDatum,Einddatum,ContractUren,VerlofDagenPerJaar,ParttimePercentage")] Contract contract)
        {
            if (id != contract.ContractID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ContractRepository.Update(contract);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ContractExists(contract.ContractID))
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
            return View(contract);
        }

        // GET: Contracten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Contract contract = null;
            if (id.HasValue)
            {
                contract = await _unitOfWork.ContractRepository.GetByIdAsync(id.Value);
            }

            else
            {
                return NotFound();
            }

           
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _unitOfWork.ContractRepository.GetByIdAsync(id);
            _unitOfWork.ContractRepository.Delete(contract);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ContractExists(int id)
        {
            var res = await _unitOfWork.ContractRepository.GetAsync();
            return res.Any(e => e.ContractID == id);
        }
    }
}
