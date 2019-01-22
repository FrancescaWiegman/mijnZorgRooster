using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL.Repositories
{
	public interface IRoosterRepository : IRepository<Rooster>
	{
        Task<List<RoosterDTO>> GetAsync();
        Task<RoosterDTO> GetByIdAsync(int id);
        Task<RoosterMetDienstProfielenDTO> GetRoosterMetDienstProfielenDto(int? roosterId);
		Task UpdateRoosterDienstProfielen(int roosterId, List<int> selectedDienstProfielen);
	}
}
