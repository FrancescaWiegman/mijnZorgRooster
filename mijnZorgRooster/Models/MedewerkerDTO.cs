using mijnZorgRooster.DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models
{
    public class MedewerkerDTO
    {
        public MedewerkerDTO(Medewerker medewerker)
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

        public int MedewerkerID { get; set; }

        [StringLength(40)]
        public string Voornaam { get; set; }

        [StringLength(40)]
        public string Achternaam { get; set; }

        [Display(Name = "Tussenvoegsel(s)")]
        public string Tussenvoegsels { get; set; }

        [StringLength(12)]
        public string Telefoonnummer { get; set; }

        [StringLength(12), Display(Name = "Mobiel Telefoonnummer")]
        public string MobielNummer { get; set; }

        [StringLength(40), Display(Name = "E-mailadres")]
        public string Emailadres { get; set; }

        [StringLength(100)]
        public string Adres { get; set; }

        [StringLength(6)]
        public string Postcode { get; set; }

        [StringLength(50)]
        public string Woonplaats { get; set; }

        [StringLength(10), DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        public int LeeftijdInJaren { get; set; }

        public string Naam { get { return string.Concat(Voornaam, " ", Tussenvoegsels, " ", Achternaam); } }
    }
}
