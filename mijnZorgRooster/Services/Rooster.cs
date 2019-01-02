using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models.Rooster
{
	public class Rooster
	{
		private int maand;
		private int jaar;
		private Boolean isGevalideerd;
		private int aantalDagen;


		public Rooster(DateTime datum)
		{
			this.maand = datum.Month;
			this.jaar = datum.Year;
			this.isGevalideerd = false;
			this.aantalDagen = geefAantalDagen(maand, jaar);
		}

		public int getMaand() { return maand; }

		public int getJaar() { return jaar; }

		public int getAantalDagen () { return aantalDagen; }

		public void setIsGevalideerd(Boolean validatie)
		{
			this.isGevalideerd = validatie;
		}

		private int geefAantalDagen(int maand, int jaar)
		{
			return DateTime.DaysInMonth(jaar, maand);
		}
	}
}
