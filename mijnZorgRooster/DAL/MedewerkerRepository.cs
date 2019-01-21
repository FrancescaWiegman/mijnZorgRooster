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
            Medewerker medewerker = await _context.Medewerkers
                .Include(m => m.MedewerkersRollen)
                .ThenInclude(r => r.Rol)
                .Where(m => m.MedewerkerID == medewerkerId)
                .SingleOrDefaultAsync();

            MedewerkerMetRollenDto dto = new MedewerkerMetRollenDto(medewerker)
            {
                SelectedRollen = medewerker.MedewerkersRollen.Select(mr => mr.RolId).ToList(),
                RollenOptions = new SelectList(rollen, nameof(Rol.RolID), nameof(Rol.Naam)),
            };

            return dto;
        }

        public async Task<Medewerker> GetMedewerkerMetRollen(int? medewerkerId)
        {
            return await _context.Medewerkers
                .Include(m => m.MedewerkersRollen)
                .ThenInclude(r => r.Rol)
                .Where(m => m.MedewerkerID == medewerkerId)
                .SingleOrDefaultAsync();
        }

        public void UpdateMedewerkerRollen(Medewerker medewerker, List<int> selectedRollen)
        {
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

