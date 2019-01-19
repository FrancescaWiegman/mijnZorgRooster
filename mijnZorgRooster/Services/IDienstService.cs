using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Services
{
	public interface IDienstService
	{
        List<Dienst> GenereerDiensten(RoosterMetDienstProfielenDto rooster, List<int> dienstProfielen);

        List<Dienst> GenereerDiensten(RoosterMetDienstProfielenDto roosterDto, List<DienstProfiel> dienstProfielen);
		DienstProfiel ConvertIdToDienstProfiel(int dienstProfielId, List<DienstProfiel> dienstProfielen);
	}
}
