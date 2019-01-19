using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
	public interface IRoosterRepository : IGenericRepository<Rooster>
	{
        Task<List<RoosterBasisDto>> GetRoosters();
        Task<RoosterDetailDto> GetRooster(int? id);

        Task<RoosterMetDienstProfielenDto> GetRoosterMetDienstProfielenDto(int? roosterId);
		Task<Rooster> GetRoosterMetDienstProfielen(int? roosterId);
		Task UpdateRoosterDienstProfielen(int roosterId, List<int> selectedDienstProfielen);
	}
}
