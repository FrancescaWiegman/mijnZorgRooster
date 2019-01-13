using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models.DTO
{
    public class MedewerkerMetRollenDto : MedewerkerBasisDto
    {
        [BindProperty]
        [Display(Name = "Rollen")]
        public List<int> SelectedRollen { get; set; }
        public SelectList RollenOptions { get; set; }
    }
}
