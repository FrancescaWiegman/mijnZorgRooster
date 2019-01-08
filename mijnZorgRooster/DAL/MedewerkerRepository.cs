using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
    public class MedewerkerRepository : GenericRepository<Medewerker>, IMedewerkerRepository
    {
        public MedewerkerRepository(ZorginstellingContext context) : base(context)
        {
        }

        public Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId)
        {
            return _context.Contracten.FirstOrDefault(c => c.BeginDatum <= referenceDate && c.Einddatum >= referenceDate && c.Medewerker.MedewerkerID == medewerkerId);
        }

    }
    }

