using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models.Entities
{
    public class Medewerker
    {
        [Key]
        [ScaffoldColumn(false)]
        public int MedewerkerID { get; set; }

        //[Required, StringLength(40), Display(Name = "Voornaam")]
        public String Voornaam { get; set; }

        //[Required, StringLength(40), Display(Name ="Achternaam")]
        public String Achternaam { get; set; }

        //[Display(Name = "Tussenvoegsels(s)")]
        public String Tussenvoegsels { get; set; }

        //[StringLength(12), Display(Name ="Telefoonnummer")]
        public String Telefoonnummer { get; set; }

        //[Required, StringLength(12), Display(Name = "Mobiel Telefoonnummer")]
        public String MobielNummer { get; set; }

        //[Required, StringLength(40), Display(Name ="E-mailadres")]
        public String Emailadres { get; set; }

        //[Required, StringLength(100), Display(Name = "Adres")]
        public String Adres { get; set; }

        //[Required, StringLength(6), Display(Name ="Postcode")]
        public String Postcode { get; set; }

        //[Required, StringLength(50), Display(Name ="Woonplaats")]
        public String Woonplaats { get; set; }

        //[Required, StringLength(10), Display(Name = "Geboortedatum")] //dit in view mogelijk nog omzetten naar juiste formaat
        public DateTime Geboortedatum { get; set; }

        public ICollection<Contract> Contracten { get; set; }
        public ICollection<Certificaat> Certificaten { get; set; }
        public ICollection <Rol> Rollen { get; set; }

        //er moet een methode komen om de leeftijd in jaren te berekenen. Deze is nodig om het aantal vrije dagen te bepalen. Hoe doe ik dat? //vraag ik op mijn werk
        //Wanneer ik weet hoe dit moet, 
        //De view wordt dan ook aangemaakt en dan kunnen er medewerkers worden toegevoegd. 
    }
}
