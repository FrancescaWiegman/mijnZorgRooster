using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public class MedewerkerRepository : GenericRepository<Medewerker>, IMedewerkerRepository
    {
        public MedewerkerRepository(ZorginstellingDbContext context) : base(context)
        {
        }

        public async Task<Medewerker> GetMedewerkerMetRollen(int? medewerkerId)
        {
            Medewerker medewerker = await _context.Medewerkers.Include(m => m.MedewerkersRollen).ThenInclude(r => r.Rol).Where(m => m.MedewerkerID == medewerkerId).SingleOrDefaultAsync();
            return medewerker;
        }

        public Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId)
        {
            return _context.Contracten.FirstOrDefault(c => c.BeginDatum <= referenceDate && c.Einddatum >= referenceDate && c.Medewerker.MedewerkerID == medewerkerId);
        }

    }
    }

