using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL.Repositories
{
    public interface IDienstProfielRepository: IRepository<DienstProfiel>
    {
        Task<List<DienstProfielDTO>> GetAsync();
        Task<DienstProfielDTO> GetByIdAsync(int id);
    }
}
