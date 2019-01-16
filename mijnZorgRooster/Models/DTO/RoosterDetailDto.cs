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
		public DateTime EindDatum { get; set; }
		public int ToelaatbaarJaarInvoer { get; set; }
	}
}
