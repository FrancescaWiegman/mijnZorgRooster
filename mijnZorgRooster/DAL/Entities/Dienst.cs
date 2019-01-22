using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.DAL.Entities
{
	public class Dienst
	{
		[Key]
		public int DienstID { get; set; }
		public DateTime Datum { get; set; }
		public DienstProfiel DienstProfiel { get; set; }
		public virtual ICollection<Medewerker> Medewerkers { get; set; }
        public int? RoosterID { get; set; }
        public Rooster Rooster { get; set; }
    }

	public class MedewerkerDienst
	{
		public int MedewerkerId { get; set; }
		public virtual Medewerker Medewerker { get; set; }
		public int DienstId { get; set; }
		public virtual Dienst Dienst { get; set; }
	}
}
