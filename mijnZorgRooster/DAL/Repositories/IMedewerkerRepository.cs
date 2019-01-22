using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL.Repositories
{
    public interface IMedewerkerRepository : IRepository<Medewerker>
    {
        Task<List<MedewerkerDTO>> GetAsync();
        Task<MedewerkerDTO> GetByIdAsync(int? id);
        Task<MedewerkerMetRollenDTO> GetMedewerkerMetRollenMappedDto(int? medewerkerId);
        Task<Medewerker> GetMedewerkerMetRollen(int? medewerkerId);
        void UpdateMedewerkerRollen(Medewerker medewerker, List<int> selectedRollen);
        Contract GetContractVoorMedewerker(DateTime referenceDate, int medewerkerId);
    }
}
