using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.DTO;

namespace mijnZorgRooster.Services
{
    public interface IRoosterService
    {
		int telAantalGeselecteerdeDienstProfielen(RoosterMetDienstProfielenDto rooster);
	}
}
