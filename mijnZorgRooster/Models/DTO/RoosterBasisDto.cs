using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Models.DTO
{
	public class RoosterBasisDto
	{
		public RoosterBasisDto() { }
		public RoosterBasisDto(Rooster rooster)
		{
			RoosterID = rooster.RoosterID;
			Jaar = rooster.Jaar;
			Maand = rooster.Maand;
			AanmaakDatum = rooster.AanmaakDatum;
			LaatsteWijzigingsDatum = rooster.LaatsteWijzigingsDatum;
			IsGevalideerd = rooster.IsGevalideerd;
			Diensten = rooster.Diensten;
		}
		public int RoosterID { get; set; }
		public int Jaar { get; set; }
		public int Maand { get; set; }
		public DateTime AanmaakDatum { get; set; }
		public DateTime LaatsteWijzigingsDatum { get; set; }
		public Boolean IsGevalideerd { get; set; }
		public ICollection<Dienst> Diensten { get; set; }
	}
}
