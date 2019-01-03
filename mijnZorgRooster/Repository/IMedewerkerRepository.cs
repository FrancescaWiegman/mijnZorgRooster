using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Services
{
    public interface IMedewerkerRepository
    {
        Medewerker GetMedewerkerById(int MedewerkerID);
        Contract GetContractForEmployee(DateTime referenceDate, int medewerkerId);
    }
}
