using mijnZorgRooster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.Repository
{
    public interface IMedewerkerRepository
    {
        Task<List<Medewerker>> GetAllMedewerkers();
        Task<Medewerker> GetMedewerkerById(int medewerkerID);
        Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId);
    }
}
