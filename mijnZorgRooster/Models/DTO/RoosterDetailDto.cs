using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Models.DTO
{
	public class RoosterDetailDto : RoosterBasisDto
	{
		public RoosterDetailDto(Rooster rooster)
		{
			Jaar = rooster.Jaar;
			Maand = rooster.Maand;
			AanmaakDatum = rooster.AanmaakDatum;
			LaatsteWijzigingsDatum = rooster.LaatsteWijzigingsDatum;
			IsGevalideerd = rooster.IsGevalideerd;
		}
		public int AantalDagen { get; set; }
		//TODO: Kijken hoe ik de startdatum van een rooster kan weergeven in de Index view, zodat de tabel erop gesorteerd kan worden
		public DateTime StartDatum { get; set; }
		//TODO: Zorgen dat ik onderstaande waarde kan gebruiken om het huidige jaar als minimale waarde kan opgeven voor 'Jaar' in
		// de Create en Edit views, zodat ik dat niet meer hard in het formulier hoef te coderen.
		public int toelaatbaarJaarInvoer { get; set; }
	}
}
