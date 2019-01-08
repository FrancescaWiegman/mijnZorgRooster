using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Data;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Views.Contract
{
    public class ContractsController : Controller
    {
        private readonly ZorginstellingContext _context;

        public ContractsController(ZorginstellingContext context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContractDto.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractDto = await _context.ContractDto
                .FirstOrDefaultAsync(m => m.ContractID == id);
            if (contractDto == null)
            {
                return NotFound();
            }

            return View(contractDto);
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
        public async Task<IActionResult> Create([Bind("BeginDatum,Einddatum,ContractUren,VerlofDagenPerJaar,ParttimePercentage")] ContractDto contractDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractDto);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractDto = await _context.ContractDto.FindAsync(id);
            if (contractDto == null)
            {
                return NotFound();
            }
            return View(contractDto);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeginDatum,Einddatum,ContractUren,VerlofDagenPerJaar,ParttimePercentage")] ContractDto contractDto)
        {
            if (id != contractDto.ContractID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractDtoExists(contractDto.ContractID))
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
            return View(contractDto);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractDto = await _context.ContractDto
                .FirstOrDefaultAsync(m => m.ContractID == id);
            if (contractDto == null)
            {
                return NotFound();
            }

            return View(contractDto);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractDto = await _context.ContractDto.FindAsync(id);
            _context.ContractDto.Remove(contractDto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractDtoExists(int id)
        {
            return _context.ContractDto.Any(e => e.ContractID == id);
        }
    }
}
