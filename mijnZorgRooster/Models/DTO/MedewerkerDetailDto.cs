using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Models.DTO
{
    public class MedewerkerDetailDto : MedewerkerBasisDto
    {

        public MedewerkerDetailDto(Medewerker medewerker)
        {
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

        public string Naam { get { return string.Concat(Voornaam, " ", Tussenvoegsels, " ", Achternaam); } }

    }
  }
