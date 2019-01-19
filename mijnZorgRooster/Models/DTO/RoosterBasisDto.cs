using mijnZorgRooster.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

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
			WijzigingsDatum = rooster.WijzigingsDatum;
			IsGevalideerd = rooster.IsGevalideerd;
		}
		public int RoosterID { get; set; }

        public int Jaar { get; set; }
		public int Maand { get; set; }
        [Display(Name = "Aantal dienstprofielen")]
        public int AantalDienstProfielen { get; set; }
        [Display(Name = "Aantal diensten")]
        public int AantalDiensten { get; set; }
        [Display(Name = "Aanmaakdatum")]
        public DateTime AanmaakDatum { get; set; }
        [Display(Name = "Wijzigingsdatum")]
        public DateTime WijzigingsDatum { get; set; }
        [Display(Name = "Gevalideerd?")]
        public Boolean IsGevalideerd { get; set; }
	}
}
