using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mijnZorgRooster.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models.DTO
{
    public class MedewerkerBasisDto
    {        
            public int MedewerkerID { get; set; }
            public String Voornaam { get; set; }
            public String Achternaam { get; set; }
            public String Tussenvoegsels { get; set; }
            public String Telefoonnummer { get; set; }
            [Display(Name = "Mobiel Telefoonnummer")]
            public String MobielNummer { get; set; }

            [Display(Name = "E-mailadres")]
            public String Emailadres { get; set; }

            public String Adres { get; set; }

            public String Postcode { get; set; }

            public String Woonplaats { get; set; }

            public DateTime Geboortedatum { get; set; }

            //public ICollection<Contract> Contracts { get; set; }
            //public ICollection<Certificate> Certificates { get; set; }
            //public ICollection<Roll> Rols { get; set; }

            [BindProperty]
            [Display(Name = "Rollen")]
            public IList<Rol> SelectedRollen { get; set; }
            public SelectList RollenOptions { get; set; }
    }
}
