using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mijnZorgRooster.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models
    {
	public class RoosterMetDienstProfielenDTO : RoosterDTO
	{
        public RoosterMetDienstProfielenDTO(Rooster rooster) : base(rooster)
        {
        }

        [BindProperty]
		[Display(Name = "DienstProfielen")]
		public List<int> SelectedDienstProfielen { get; set; }
		public SelectList DienstProfielOptions { get; set; }
	}
}
