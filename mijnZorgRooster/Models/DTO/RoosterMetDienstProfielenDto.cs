using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models.DTO
{
	public class RoosterMetDienstProfielenDto : RoosterBasisDto
	{
        [BindProperty]
		[Display(Name = "DienstProfielen")]
		public List<int> SelectedDienstProfielen { get; set; }
		public SelectList DienstProfielOptions { get; set; }
	}
}
