using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Data;
using mijnZorgRooster.Models;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using mijnZorgRooster.Repository;
using mijnZorgRooster.Services;


namespace mijnZorgRooster.Controllers
{
    public class MedewerkersController : Controller
    {
        private readonly IMedewerkerRepository _repository;
        private readonly ICalculationsService _calculationsService;
        private readonly IUnitOfWork _unitOfWork;
            
        public MedewerkersController(IMedewerkerRepository repository, ICalculationsService calculationsService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _calculationsService = calculationsService;
            _unitOfWork = unitOfWork;
        }

        // GET: Medewerkers
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllMedewerkers());
        }

        // GET: Medewerkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Medewerker medewerker = null;
    
            if (id.HasValue)
            {
                medewerker = await _repository.GetMedewerkerById(id.Value);
            }
            else
            {
                return NotFound();
            }


            MedewerkerDetailDto medewerkerDetails = new MedewerkerDetailDto(medewerker);

            medewerkerDetails.LeeftijdInJaren = await _calculationsService.BerekenLeeftijdInJaren(medewerker.MedewerkerID);
            medewerkerDetails.Achternaam = medewerker.Achternaam;
            medewerkerDetails.Voornaam = medewerker.Voornaam;
            
            return View(medewerkerDetails);
        }

        // GET: Medewerkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medewerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("medewerkerID,Voornaam,Achternaam,Tussenvoegsels,Telefoonnummer,MobielNummer,Emailadres,Adres,Postcode,Woonplaats,Geboortedatum")] Medewerker medewerker)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(medewerker);
        //        await _unitOfWork.CommitAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(medewerker);
        //}

        //// GET: Medewerkers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var medewerker = await _context.Medewerkers.FindAsync(id);
        //    if (medewerker == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(medewerker);
        //}

        //// POST: Medewerkers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("medewerkerID,Voornaam,Achternaam,Tussenvoegsels,Telefoonnummer,MobielNummer,Emailadres,Adres,Postcode,Woonplaats,Geboortedatum")] Medewerker medewerker)
        //{
        //    if (id != medewerker.MedewerkerID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(medewerker);
        //            await 
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MedewerkerExists(medewerker.MedewerkerID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(medewerker);
        //}

        //// GET: Medewerkers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    Medewerker medewerker = null;
        //    if (id.HasValue)
        //    {
        //        medewerker = await _repository.GetMedewerkerById(id.Value);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //    if (medewerker == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(medewerker);
        //}

        //// POST: Medewerkers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var medewerker = await _repository.GetMedewerkerById(id);
        //    _context.Medewerkers.Remove(medewerker);
        //    await _unitOfWork.CommitAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MedewerkerExists(int id)
        //{
        //    return _context.Medewerkers.Any(e => e.MedewerkerID == id);
        //}
    }
}
