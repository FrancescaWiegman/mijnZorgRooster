using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Services;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.DAL.Repositories;

namespace mijnZorgRooster.Controllers
{
    public class ContractenController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContractRepository _contractRepository;
        private readonly ICalculationsService _calculationService;

        public int MedewerkerID { get; private set; }

        public ContractenController(ICalculationsService calculationService, IUnitOfWork unitOfWork, IContractRepository contractRepository)
        {
            _calculationService = calculationService;
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork; ;
        }

        // GET: Contracten
        public async Task<IActionResult> Index()
        {
            return View(await _contractRepository.GetAsync());
        }

        // GET: Contracten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ContractDTO contractDTO = null;

            if (id.HasValue)
            {
                contractDTO = await _contractRepository.GetByIdAsync(id.Value);
            }
            else


            {
                return NotFound();
            }

            //TODO:
            //contractDTO.ParttimePercentage = _calculationService.BerekenParttimePercentage(contract.Medewerker.MedewerkerID);

            return View(contractDTO);
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
                _contractRepository.Insert(contract);
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

            ContractDTO contractDTO = await _contractRepository.GetByIdAsync(id.Value);

            if (contractDTO == null)
            {
                return NotFound();
            }
            return View(contractDTO);
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
                    _contractRepository.Update(contract);
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
            ContractDTO contractDTO = null;
            if (id.HasValue)
            {
                contractDTO = await _contractRepository.GetByIdAsync(id.Value);
            }

            else
            {
                return NotFound();
            }

           
            if (contractDTO == null)
            {
                return NotFound();
            }

            return View(contractDTO);
        }

        // POST: Contracten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _contractRepository.Delete(id);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ContractExists(int id)
        {
            var res = await _contractRepository.GetAsync();
            return res.Any(e => e.ContractID == id);
        }
    }
}
