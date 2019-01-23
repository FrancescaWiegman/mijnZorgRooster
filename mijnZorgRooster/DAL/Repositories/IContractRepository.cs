using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL.Repositories
{
    public interface IContractRepository: IRepository<Contract>
    {
        Task<List<ContractDTO>> GetAsync();
        Task<ContractDTO> GetByIdAsync(int id);
    }
}
