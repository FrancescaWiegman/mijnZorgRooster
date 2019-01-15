using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models.Entities
{
	public class Dienst
	{
		[Key]
		public int DienstID { get; set; }
		public DateTime Datum { get; set; }
		public DienstProfiel DienstProfiel { get; set; }
		public ICollection<Medewerker> Medewerkers { get; set; }
	}
}
