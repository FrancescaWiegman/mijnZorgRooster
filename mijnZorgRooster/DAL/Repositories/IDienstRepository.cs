using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL.Repositories
{
    public interface IDienstRepository : IRepository<Dienst>
	{
        List<Dienst> GenereerDiensten(int roosterID, List<int> dienstProfielen);
        Task<DienstDTO> GetByIdAsync(int? dienstId);
        Task<List<DienstDTO>> GetAsync();

    }
}
