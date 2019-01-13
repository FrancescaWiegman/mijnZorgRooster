using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
