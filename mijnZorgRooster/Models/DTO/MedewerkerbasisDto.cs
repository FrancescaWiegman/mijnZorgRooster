using System;

namespace mijnZorgRooster.Models.DTO
{
    public class MedewerkerBasisDto
    {        
            public int MedewerkerID { get; set; }
            public String Voornaam { get; set; }
            public String Achternaam { get; set; }
            public String Tussenvoegsels { get; set; }
            public String Telefoonnummer { get; set; }
            public String MobielNummer { get; set; }
            public String Emailadres { get; set; }
            public String Adres { get; set; }
            public String Postcode { get; set; }
            public String Woonplaats { get; set; }
            public DateTime Geboortedatum { get; set; }
        }
    }

