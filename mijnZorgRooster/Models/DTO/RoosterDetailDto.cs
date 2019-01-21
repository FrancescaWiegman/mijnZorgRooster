using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Models.DTO
{
	public class RoosterDetailDto : RoosterBasisDto
	{
		public RoosterDetailDto() { }
		public RoosterDetailDto(Rooster rooster) : base(rooster)
        {
            Diensten = rooster.Diensten;
        }
		public string EditViewErrorMessage { get; set; }
        public ICollection<Dienst> Diensten { get; set; }

        [Display(Name = "Aantal dagen")]
        public int AantalDagen { get { return DateTime.DaysInMonth(Jaar, Maand); } }
        public DateTime StartDatum { get { return new DateTime(Jaar, Maand, 1); } }
        public DateTime EindDatum { get { return StartDatum.AddMonths(1).AddTicks(-1); } }
    }
}
