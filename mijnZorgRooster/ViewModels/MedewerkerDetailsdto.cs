using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.ViewModels
{
    public class MedewerkerDetailsdto : MedewerkerbasisDto
    {

        public MedewerkerDetailsdto(Medewerker medewerker)
        {
            MedewerkerID = medewerker.MedewerkerID;
            Voornaam = medewerker.Voornaam;
            Achternaam = medewerker.Achternaam;
            Tussenvoegsels = medewerker.Tussenvoegsels;
            Telefoonnummer = medewerker.Telefoonnummer;
            MobielNummer = medewerker.MobielNummer;
            Emailadres = medewerker.Emailadres;
            Adres = medewerker.Adres;
            Postcode = medewerker.Postcode;
            Woonplaats = medewerker.Woonplaats;
            Geboortedatum = medewerker.Geboortedatum;
        }
        public int LeeftijdInJaren { get; set; }
        
    }
  }
