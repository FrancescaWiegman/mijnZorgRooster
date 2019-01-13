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
	}
}
