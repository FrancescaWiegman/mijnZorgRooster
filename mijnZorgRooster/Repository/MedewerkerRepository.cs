using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Data;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Repository
{
    public class MedewerkerRepository : IMedewerkerRepository
    {
        private readonly ZorginstellingContext _context;

        public MedewerkerRepository(ZorginstellingContext context)
        {
            _context = context;
        }

        public Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId)
        {
            return _context.Contracten.FirstOrDefault(c => c.BeginDatum <= referenceDate && c.Einddatum >= referenceDate && c.Medewerker.MedewerkerID == medewerkerId);
        }

        public Medewerker GetMedewerkerById(int medewerkerID)
        {
            return _context.Medewerkers.FirstOrDefault(m => m.MedewerkerID == medewerkerID);
        }
    }
    }

