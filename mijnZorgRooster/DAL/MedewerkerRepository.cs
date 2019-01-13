using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public class MedewerkerRepository : GenericRepository<Medewerker>, IMedewerkerRepository
    {
        public MedewerkerRepository(ZorginstellingDbContext context) : base(context)
        {
        }

        public async Task<MedewerkerMetRollenDto> GetMedewerkerMetRollenMappedDto(int? medewerkerId)
        {
            List<Rol> rollen = await _context.Rollen.ToListAsync();
            MedewerkerMetRollenDto medewerker = await _context.Medewerkers
                .Include(m => m.MedewerkersRollen)
                .ThenInclude(r => r.Rol)
                .Where(m => m.MedewerkerID == medewerkerId)
                .Select(m => new MedewerkerMetRollenDto()
                {
                    MedewerkerID = m.MedewerkerID,
                    Voornaam = m.Voornaam,
                    Tussenvoegsels = m.Tussenvoegsels,
                    Telefoonnummer = m.Telefoonnummer,
                    MobielNummer = m.MobielNummer,
                    Emailadres = m.Emailadres,
                    Adres = m.Adres,
                    Postcode = m.Postcode,
                    Woonplaats = m.Woonplaats,
                    Geboortedatum = m.Geboortedatum,
                    SelectedRollen = m.MedewerkersRollen.Select(mr => mr.RolId).ToList(),
                    RollenOptions = new SelectList(rollen, nameof(Rol.RolID), nameof(Rol.Naam)),
                    Achternaam = m.Achternaam
                })
                .SingleOrDefaultAsync();
            return medewerker;
        }

        public async Task<Medewerker> GetMedewerkerMetRollen(int? medewerkerId)
        {
            return await _context.Medewerkers
                .Include(m => m.MedewerkersRollen)
                .ThenInclude(r => r.Rol)
                .Where(m => m.MedewerkerID == medewerkerId)
                .SingleOrDefaultAsync();
        }

        public async Task UpdateMedewerkerRollen(int medewerkerId, List<int> selectedRollen)
        {
            Medewerker medewerker = await GetMedewerkerMetRollen(medewerkerId);
            medewerker.MedewerkersRollen.Clear();

            foreach (var selectedRolId in selectedRollen)
            {
                Rol rol = _context.Rollen.Where(r => r.RolID == selectedRolId).SingleOrDefault();
                medewerker.MedewerkersRollen.Add(new MedewerkerRol() {
                    Medewerker = medewerker,
                    Rol = rol,
                });
            }
        }

        public Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId)
        {
            return _context.Contracten.FirstOrDefault(c => c.BeginDatum <= referenceDate && c.Einddatum >= referenceDate && c.Medewerker.MedewerkerID == medewerkerId);
        }

    }
    }

