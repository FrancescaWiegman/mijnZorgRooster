using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Models.DTO
{
	public class RoosterDetailDto : RoosterBasisDto
	{
		public RoosterDetailDto(Rooster rooster) : base(rooster)
		{
		}
		public int AantalDagen { get; set; }
		public DateTime StartDatum { get; set; }
		public DateTime EindDatum { get; set; }
		public int ToelaatbaarJaarInvoer { get; set; }
	}
}
