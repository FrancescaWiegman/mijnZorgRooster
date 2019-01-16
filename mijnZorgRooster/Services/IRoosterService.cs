using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.DTO;

namespace mijnZorgRooster.Services
{
    public interface IRoosterService
    {
		DateTime geefDatumVanVandaag();
		int geefAantalDagen(int maand, int jaar);
		DateTime genereerStartDatum(int maand, int jaar);
		DateTime genereerEindDatum(int maand, int jaar);
		int geefToelaatbaarJaarInvoer();
		int telAantalGeselecteerdeDienstProfielen(RoosterMetDienstProfielenDto rooster);
	}
}
