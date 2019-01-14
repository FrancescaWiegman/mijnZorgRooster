using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using mijnZorgRooster.Services;

namespace mijnZorgRooster.Controllers
{
    public class ContractsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContractService _contractService;

        public int MedewerkerID { get; private set; }

        public ContractsController(ContractService contractService, IUnitOfWork unitOfWork)
        {
            _contractService = contractService;
            _unitOfWork = unitOfWork; ;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.ContractRepository.GetAsync());
        }

        // GET: Contracts/Details/5
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
            //ContractDetailDto contractDetails = new ContractDetailDto()
            {
                //TODO: ik moet op één of andere manier de Parttimepercentage er in krijgen. Ik doe iets verkeerd. Weet iemand wat?
                //BerekenParttimePercentage = await _contractService.BerekenParttimePercentage(contract.MedewerkerID)
                
                //ContractID = contract.ContractID;
                
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Contracts/Edit/5
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

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Contracts/Delete/5
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

        // POST: Contracts/Delete/5
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
