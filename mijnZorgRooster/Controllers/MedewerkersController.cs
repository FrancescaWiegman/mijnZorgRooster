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
    public class MedewerkersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalculationsService _calculationsService;
            
        public MedewerkersController(ICalculationsService calculationsService, IUnitOfWork unitOfWork)
        {
            _calculationsService = calculationsService;
            _unitOfWork = unitOfWork;
        }

        // GET: Medewerkers
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.MedewerkerRepository.GetAsync());
        }

        // GET: Medewerkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Medewerker medewerker = null;
    
            if (id.HasValue)
            {
                medewerker = await _unitOfWork.MedewerkerRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }


            MedewerkerDetailDto medewerkerDetails = new MedewerkerDetailDto(medewerker)
            {
                LeeftijdInJaren = await _calculationsService.BerekenLeeftijdInJaren(medewerker.MedewerkerID),
                Achternaam = medewerker.Achternaam,
                Voornaam = medewerker.Voornaam
            };

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("medewerkerID,Voornaam,Achternaam,Tussenvoegsels,Telefoonnummer,MobielNummer,Emailadres,Adres,Postcode,Woonplaats,Geboortedatum")] Medewerker medewerker)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MedewerkerRepository.Insert(medewerker);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medewerker);
        }

        //// GET: Medewerkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = await _unitOfWork.MedewerkerRepository.GetByIdAsync(id);
            if (medewerker == null)
            {
                return NotFound();
            }

            IEnumerable<Rol> rollen = await _unitOfWork.RolRepository.GetAsync();

            MedewerkerBasisDto medewerkerBasisDto = new MedewerkerBasisDto()
            {
                Voornaam = medewerker.Voornaam,
                Tussenvoegsels = medewerker.Tussenvoegsels,
                Telefoonnummer = medewerker.Telefoonnummer,
                MobielNummer = medewerker.MobielNummer,
                Emailadres = medewerker.Emailadres,
                Adres = medewerker.Adres,
                Postcode = medewerker.Postcode,
                Woonplaats = medewerker.Woonplaats,
                Geboortedatum = medewerker.Geboortedatum,
                SelectedRollen = medewerker.Rollen.ToList(),
                RollenOptions = new SelectList(rollen)
            };

            return View(medewerkerBasisDto);
        }

        //// POST: Medewerkers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedewerkerID,Voornaam,Achternaam,Tussenvoegsels,Telefoonnummer,MobielNummer,Emailadres,Adres,Postcode,Woonplaats,Geboortedatum")] Medewerker medewerker)
        {
            if (id != medewerker.MedewerkerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.MedewerkerRepository.Update(medewerker);
                    await _unitOfWork.SaveAsync();
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

        //// GET: Medewerkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Medewerker medewerker = null;
            if (id.HasValue)
            {
                medewerker = await _unitOfWork.MedewerkerRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }

            if (medewerker == null)
            {
                return NotFound();
            }

            return View(medewerker);
        }

        // POST: Medewerkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medewerker = await _unitOfWork.MedewerkerRepository.GetByIdAsync(id);
            _unitOfWork.MedewerkerRepository.Delete(medewerker);
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
