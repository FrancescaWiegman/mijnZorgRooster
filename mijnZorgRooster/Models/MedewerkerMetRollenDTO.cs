using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mijnZorgRooster.DAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models
{
    public class MedewerkerMetRollenDTO : MedewerkerDTO
    {
        public MedewerkerMetRollenDTO(Medewerker medewerker) : base(medewerker)
        {
        }

        [BindProperty]
        [Display(Name = "Rollen")]
        public List<int> SelectedRollen { get; set; }
        public SelectList RollenOptions { get; set; }
    }
}
