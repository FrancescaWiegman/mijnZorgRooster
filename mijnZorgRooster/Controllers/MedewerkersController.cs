using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.DAL.Repositories;

namespace mijnZorgRooster.Controllers
{
    public class MedewerkersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalculationsService _calculationsService;
        private readonly IMedewerkerRepository _medewerkerRepository;
            
        public MedewerkersController(ICalculationsService calculationsService, IUnitOfWork unitOfWork, IMedewerkerRepository medewerkerRepository)
        {
            _calculationsService = calculationsService;
            _unitOfWork = unitOfWork;
            _medewerkerRepository = medewerkerRepository;
        }

        // GET: Medewerkers
        public async Task<IActionResult> Index()
        {
            return View(await _medewerkerRepository.GetAsync());
        }

        // GET: Medewerkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            MedewerkerDTO medewerkerDTO = null;
    
            if (id.HasValue)
            {
                medewerkerDTO = await _medewerkerRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }

            medewerkerDTO.LeeftijdInJaren = _calculationsService.BerekenLeeftijdInJaren(medewerkerDTO.Geboortedatum);


            return View(medewerkerDTO);
        }

        // GET: Medewerkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medewerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("medewerkerID,Voornaam,Achternaam,Tussenvoegsels,Telefoonnummer,MobielNummer," +
             "Emailadres,Adres,Postcode,Woonplaats,Geboortedatum")] Medewerker medewerker)
        {
            if (ModelState.IsValid)
            {
                _medewerkerRepository.Insert(medewerker);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medewerker);
        }

        // GET: Medewerkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedewerkerMetRollenDTO medewerkerDto = await _medewerkerRepository.GetMedewerkerMetRollenMappedDto(id);

            if (medewerkerDto == null)
            {
                return NotFound();
            }
            
            return View(medewerkerDto);
        }


        // POST: Medewerkers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MedewerkerID,Voornaam,Achternaam,Tussenvoegsels,Telefoonnummer,MobielNummer,Emailadres,Adres,Postcode,Woonplaats,Geboortedatum")] Medewerker medewerker, List<int> SelectedRollen)
        {
            if (medewerker.MedewerkerID == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _medewerkerRepository.Update(medewerker);

                    var oudMedewerker = await _medewerkerRepository.GetMedewerkerMetRollen(medewerker.MedewerkerID);
                    var lijstMetRollenIds = oudMedewerker.MedewerkersRollen.Select(mr => mr.RolId).ToList();
                    if (!lijstMetRollenIds.SequenceEqual(SelectedRollen)) //check of de rollen van medewerker is veranderd
                        _medewerkerRepository.UpdateMedewerkerRollen(oudMedewerker, SelectedRollen);

                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MedewerkerExists(medewerker.MedewerkerID))
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
            return View(medewerker);
        }

        // GET: Medewerkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            MedewerkerDTO medewerkerDTO = null;

            if (id.HasValue)
            {
                medewerkerDTO = await _medewerkerRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }

            return View(medewerkerDTO);
        }

        // POST: Medewerkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _medewerkerRepository.Delete(id);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MedewerkerExists(int id)
        {
            var res = await _medewerkerRepository.GetAsync();
            return res.Any(m => m.MedewerkerID == id);
        }
    }
}
