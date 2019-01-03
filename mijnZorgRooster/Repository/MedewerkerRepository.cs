using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Data;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Services
{
    public class MedewerkerRepository : IMedewerkerRepository
    {
        private readonly ZorginstellingContext _context;

        public MedewerkerRepository(ZorginstellingContext context)
        {
            _context = context;
        }

        public Contract GetContractForEmployee(DateTime referenceDate, int medewerkerId)
        {
            return _context.Contracts.FirstOrDefault(c => c.BeginDatum <= referenceDate && c.Einddatum >= referenceDate && c.Medewerker.MedewerkerID == medewerkerId);
        }

        public Medewerker GetMedewerkerById(int MedewerkerID)
        {
            return _context.Medewerkers.FirstOrDefault(m => m.MedewerkerID == MedewerkerID);
        }
    }
    }

