using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL.Repositories
{
    public interface IRolRepository: IRepository<Rol>
    {
        Task<List<RolDTO>> GetAsync();
        Task<RolDTO> GetByIdAsync(int id);
    }
}
