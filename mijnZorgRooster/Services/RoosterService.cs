using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.DTO;

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
			string stringMaand = parseNaarTweeDecimalenString(maand);
			string input = "01-" + stringMaand + "-" + jaar;
			return DateTime.ParseExact(input, "dd-MM-yyyy", null);
		}

		public DateTime genereerEindDatum(int maand, int jaar)
		{
			string stringMaand = parseNaarTweeDecimalenString(maand);
			string stringDag = geefAantalDagen(maand, jaar).ToString();
			string input = stringDag + "-" + stringMaand + "-" + jaar + "-23-59-59";
			return DateTime.ParseExact(input, "dd-MM-yyyy-HH-mm-ss", null);
		}

		public int geefToelaatbaarJaarInvoer()
		{
			return DateTime.UtcNow.Year;
		}

		public int telAantalGeselecteerdeDienstProfielen(RoosterMetDienstProfielenDto rooster)
		{
			return rooster.SelectedDienstProfielen.Count;
		}

		private string parseNaarTweeDecimalenString(int getal)
		{
			string stringGetal;
			if (getal < 9) stringGetal = "0" + getal.ToString();
			else stringGetal = getal.ToString();
			return stringGetal;
		}
	}
}
