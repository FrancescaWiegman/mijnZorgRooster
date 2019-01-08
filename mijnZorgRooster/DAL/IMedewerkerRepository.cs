using mijnZorgRooster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public interface IMedewerkerRepository
    {
        Task<IEnumerable<Medewerker>> GetAsync();
        Task<Medewerker> GetByIdAsync(object id);
        void Insert(Medewerker medewerker);
        void Delete(object id);
        void Delete(Medewerker medewerker);
        void Update(Medewerker medewerker);
        Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId);
    }
}
