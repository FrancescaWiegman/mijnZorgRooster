using mijnZorgRooster.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models
{
    public class RoosterDTO
	{
		public RoosterDTO(Rooster rooster)
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
        [Display(Name = "Aanmaakdatum")]
        public DateTime AanmaakDatum { get; set; }
        [Display(Name = "Wijzigingsdatum")]
        public DateTime WijzigingsDatum { get; set; }
        [Display(Name = "Gevalideerd?")]
        public Boolean IsGevalideerd { get; set; }
        public IEnumerable<DienstDTO> Diensten { get; set; }
        public IEnumerable<RoosterDienstProfiel> RoosterDienstProfielen { get; set; }

        [Display(Name = "Aantal dienstprofielen")]
        public int AantalDienstProfielen { get; set; }
        [Display(Name = "Aantal diensten")]
        public int AantalDiensten { get; set; }
        [Display(Name = "Aantal dagen")]
        public int AantalDagen { get { return DateTime.DaysInMonth(Jaar, Maand); } }
        public DateTime StartDatum { get { return new DateTime(Jaar, Maand, 1); } }
        public DateTime EindDatum { get { return StartDatum.AddMonths(1).AddTicks(-1); } }
    }
}
