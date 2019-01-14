using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Services
{
    public interface IRoosterService
    {
		DateTime geefDatumVanVandaag();
		int geefAantalDagen(int maand, int jaar);
		DateTime genereerStartDatum(int maand, int jaar);
		int geefToelaatbaarJaarInvoer();
	}
}
