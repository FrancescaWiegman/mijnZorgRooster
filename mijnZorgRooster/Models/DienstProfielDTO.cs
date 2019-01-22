using System;
using mijnZorgRooster.DAL.Entities;

namespace mijnZorgRooster.Models
{
	public class DienstProfielDTO
	{
		public DienstProfielDTO()
		{
		}
		public DienstProfielDTO(DienstProfiel dienstProfiel)
		{
			DienstProfielID = dienstProfiel.DienstProfielID;
			Beschrijving = dienstProfiel.Beschrijving;
			Begintijd = dienstProfiel.Begintijd;
			Eindtijd = dienstProfiel.Eindtijd;
			MinimaleBezetting = dienstProfiel.MinimaleBezetting;
		}
		public int DienstProfielID { get; set; }
		public string Beschrijving { get; set; }
		public TimeSpan Begintijd { get; set; }
		public TimeSpan Eindtijd { get; set; }
		public int MinimaleBezetting { get; set; }
	}
}
