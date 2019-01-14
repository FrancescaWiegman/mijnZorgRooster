using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Services
{
	public class RoosterService : IRoosterService
	{

		public DateTime geefDatumVanVandaag()
		{
			return DateTime.UtcNow;
		}
		
		public int geefAantalDagen(int maand, int jaar)
		{
			return DateTime.DaysInMonth(jaar, maand);
		}

		public DateTime genereerStartDatum(int maand, int jaar)
		{
			string stringMaand;

			if (maand < 9) stringMaand = "0" + maand.ToString();
			else stringMaand = maand.ToString();

			string input = "01-" + stringMaand + "-" + jaar;
			return DateTime.ParseExact(input, "dd-MM-yyyy", null);
		}

		public int geefToelaatbaarJaarInvoer()
		{
			return DateTime.UtcNow.Year;
		}
	}
}
