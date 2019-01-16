using System;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Models.DTO
{
	public class DienstProfielDto
	{
		public DienstProfielDto()
		{
		}
		public DienstProfielDto(DienstProfiel dienstProfiel)
		{
			Beschrijving = dienstProfiel.Beschrijving;
			VolgordeNr = dienstProfiel.VolgordeNr;
			Begintijd = dienstProfiel.Begintijd;
			Eindtijd = dienstProfiel.Eindtijd;
			MinimaleBezetting = dienstProfiel.MinimaleBezetting;
		}
		public int DienstProfielID { get; set; }
		public int VolgordeNr { get; set; }
		public string Beschrijving { get; set; }
		public TimeSpan Begintijd { get; set; }
		public TimeSpan Eindtijd { get; set; }
		public int MinimaleBezetting { get; set; }
	}
}
