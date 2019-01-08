using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Data;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Repository
{
    public class MedewerkerRepository : IMedewerkerRepository
    {
        private readonly ZorginstellingContext _context;

        public MedewerkerRepository(ZorginstellingContext context)
        {
            _context = context;
        }

        public async Task<List<Medewerker>> GetAllMedewerkers()
        {
            return await _context.Medewerkers.ToListAsync();
        }

        public Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId)
        {
            return _context.Contracten.FirstOrDefault(c => c.BeginDatum <= referenceDate && c.Einddatum >= referenceDate && c.Medewerker.MedewerkerID == medewerkerId);
        }

        public async Task<Medewerker> GetMedewerkerById(int medewerkerID)
        {
            return await _context.Medewerkers.FirstOrDefaultAsync(m => m.MedewerkerID == medewerkerID);
        }
    }
    }

