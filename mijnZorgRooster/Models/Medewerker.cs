using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models
{
    public class Medewerker
    {
        public int medewerkerID { get; set; }
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

        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Certificaat> Certificaats { get; set; }
        public ICollection <Rol> Rols { get; set; }

        //er moet een methode komen om de leeftijd in jaren te berekenen. Deze is nodig om het aantal vrije dagen te bepalen. Hoe doe ik dat? //vraag ik op mijn werk
        //Wanneer ik weet hoe dit moet, Scaffold model om de CRUD mogelijk te maken. tevens database initialiseren zodat deze aangemaakt wordt.
        //De view wordt dan ook aangemaakt en dan kunnen er medewerkers worden toegevoegd. 
    }
}
