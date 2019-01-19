using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.DTO;

namespace mijnZorgRooster.Services
{
	public class RoosterService : IRoosterService
	{

		public int telAantalGeselecteerdeDienstProfielen(RoosterMetDienstProfielenDto rooster)
		{
			return rooster.SelectedDienstProfielen.Count;
		}

	}
}
