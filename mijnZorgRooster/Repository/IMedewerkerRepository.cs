using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Repository
{
    public interface IMedewerkerRepository
    {
        Medewerker GetMedewerkerById(int medewerkerID);
        Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId);
    }
}
