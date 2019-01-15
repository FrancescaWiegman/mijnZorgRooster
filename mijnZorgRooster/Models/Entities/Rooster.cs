using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models.Entities
{
	public class Rooster
	{
		[Key]
		public int RoosterID { get; set; }
		public int Jaar { get; set; }
		public int Maand { get; set; }
		public DateTime AanmaakDatum { get; set; }
		public DateTime LaatsteWijzigingsDatum { get; set; }
		public Boolean IsGevalideerd { get; set; }
		public ICollection<RoosterDienstProfiel> RoosterDienstProfielen { get; set; }
		public ICollection<Dienst> Diensten { get; set; }
		//TODO: Bij implementatie van de use case CRUD Teams, zou hier ook nog een property voor het Team moeten komen.
	}
}
