using mijnZorgRooster.DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models
{
    public class DienstDTO
	{
		public DienstDTO(Dienst dienst)
		{
			DienstID = dienst.DienstID;
			Datum = dienst.Datum;
            Beschrijving = dienst.DienstProfiel.Beschrijving;
            Begintijd = dienst.DienstProfiel.Begintijd;
            Eindtijd = dienst.DienstProfiel.Eindtijd;
            MinimaleBezetting = dienst.DienstProfiel.MinimaleBezetting;
            DienstProfielID = dienst.DienstProfiel.DienstProfielID;
		}
		public int DienstID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public string Beschrijving { get; set; }
        public TimeSpan Begintijd { get; set; }
        public TimeSpan Eindtijd { get; set; }
        public int MinimaleBezetting { get; set; }
        public int DienstProfielID { get; set; }
    }
}
