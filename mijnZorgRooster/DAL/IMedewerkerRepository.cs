using mijnZorgRooster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public interface IMedewerkerRepository
    {
        Task<IList<Medewerker>> GetAsync();
        Task<Medewerker> GetByIdAsync(object id);
        Task<Medewerker> GetMedewerkerMetRollen(int? medewerkerId);
        void Insert(Medewerker medewerker);
        void Delete(object id);
        void Delete(Medewerker medewerker);
        void Update(Medewerker medewerker);
        Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId);
    }
}
