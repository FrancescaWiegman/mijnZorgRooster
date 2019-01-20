using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
	public interface IDienstRepository : IGenericRepository<Dienst>
	{
        List<Dienst> GenereerDiensten(RoosterMetDienstProfielenDto rooster, List<int> dienstProfielen);

        Task<DienstDto> GetDienstDto(int? dienstId);
		Task<Dienst> GetDienstenMetAlleInfo(int? dienstId);
	}
}
