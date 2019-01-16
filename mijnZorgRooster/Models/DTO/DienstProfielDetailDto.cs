using System;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Models.DTO
{
	public class DienstProfielDetailDto : DienstProfielBasisDto
	{
		public DienstProfielDetailDto(DienstProfiel dienstProfiel)
		{
			Beschrijving = dienstProfiel.Beschrijving;
			VolgordeNr = dienstProfiel.VolgordeNr;
			Begintijd = dienstProfiel.Begintijd;
			Eindtijd = dienstProfiel.Eindtijd;
			MinimaleBezetting = dienstProfiel.MinimaleBezetting;
		}
	}
}
