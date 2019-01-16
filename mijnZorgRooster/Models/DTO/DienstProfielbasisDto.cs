using System;

namespace mijnZorgRooster.Models.DTO
{
	public class DienstProfielBasisDto
	{
		public int DienstProfielID { get; set; }
		public int VolgordeNr { get; set; }
		public string Beschrijving { get; set; }
		public TimeSpan Begintijd { get; set; }
		public TimeSpan Eindtijd { get; set; }
		public int MinimaleBezetting { get; set; }
	}
}
