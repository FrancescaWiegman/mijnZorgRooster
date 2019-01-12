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
		public DienstProfiel DienstData { get; set; }
		// TODO: ICollection toevoegen voor de ingeroosterde zorgverleners. Maken we een aparte Zorgverlener klasse, 
		// of gebruiken we voor nu alleen de Medewerker om het simpel te houden?
	}
}
