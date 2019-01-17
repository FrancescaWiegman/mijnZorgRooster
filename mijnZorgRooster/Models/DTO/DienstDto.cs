using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using mijnZorgRooster.Utilities;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Services;

namespace mijnZorgRooster.Models.DTO
{
	public class DienstDto
	{
		public DienstDto() { }
		public DienstDto(Dienst dienst)
		{
			DienstID = dienst.DienstID;
			Datum = dienst.Datum;
			DienstProfiel = dienst.DienstProfiel;
		}
		public int DienstID { get; set; }
		public DateTime Datum { get; set; }
		public DienstProfiel DienstProfiel { get; set; }
		public virtual ICollection<Medewerker> Medewerkers { get; set; }
		public int IngeroosterdeZorgverleners { get; set; }
		public Rooster ParentRooster { get; set; }
	}
}
