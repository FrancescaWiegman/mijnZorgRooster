using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL.Repositories
{
    public class MedewerkerRepository : IMedewerkerRepository
    {
        internal ZorginstellingDbContext _context;

        public MedewerkerRepository(ZorginstellingDbContext context)
        {
            _context = context;
        }

        public async Task<List<MedewerkerDTO>> GetAsync()
        {
            return await _context.Medewerkers
                .Select(m => new MedewerkerDTO(m))
                .ToListAsync();
        }

        public async Task<MedewerkerDTO> GetByIdAsync(int? id)
        {
            return await _context.Medewerkers
                .Where(m => m.MedewerkerID == id)
                .Select(m => new MedewerkerDTO(m))
                .SingleOrDefaultAsync();
        }
    

        public async Task<MedewerkerMetRollenDTO> GetMedewerkerMetRollenMappedDto(int? medewerkerId)
        {
            List<Rol> rollen = await _context.Rollen.ToListAsync();
            Medewerker medewerker = await _context.Medewerkers
                .Include(m => m.MedewerkersRollen)
                .ThenInclude(r => r.Rol)
                .Where(m => m.MedewerkerID == medewerkerId)
                .SingleOrDefaultAsync();

            MedewerkerMetRollenDTO dto = new MedewerkerMetRollenDTO(medewerker)
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

        public void Insert(Medewerker entity)
        {
            _context.Medewerkers.Add(entity);
        }

        public void Update(Medewerker entity)
        {
            _context.Medewerkers.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Medewerker entityToDelete = _context.Medewerkers.Find(id);
            _context.Medewerkers.Remove(entityToDelete);
        }
    }
}

