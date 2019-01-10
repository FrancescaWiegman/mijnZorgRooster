using mijnZorgRooster.Models.Entities;
using System;
using System.Linq;

namespace mijnZorgRooster.DAL
{
    public class MedewerkerRepository : GenericRepository<Medewerker>, IMedewerkerRepository
    {
        public MedewerkerRepository(ZorginstellingDbContext context) : base(context)
        {
        }

        public Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId)
        {
            return _context.Contracten.FirstOrDefault(c => c.BeginDatum <= referenceDate && c.Einddatum >= referenceDate && c.Medewerker.MedewerkerID == medewerkerId);
        }

    }
    }

