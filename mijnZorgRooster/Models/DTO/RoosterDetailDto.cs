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
	}
}
