using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models
{
    public class Medewerker
    {
        private int MedewerkerID { get; set; }
        private String Voornaam { get; set; }
        private String Achternaam { get; set; }
        private String Tussenvoegsels { get; set; }
        private String Telefoonnummer { get; set; }
        private String MobielNummer { get; set; }
        private String Emailadres { get; set; }
        private String Adres { get; set; }
        private String Postcode { get; set; }
        private String Woonplaats { get; set; }
        private DateTime Geboortedatum { get; set; }
       
        //er moet een methode komen om de leeftijd in jaren te berekenen. Deze is nodig om het aantal vrije dagen te bepalen. Hoe doe ik dat? //vraag ik op mijn werk
        //Wanneer ik weet hoe dit moet, Scaffold model om de CRUD mogelijk te maken. tevens database initialiseren zodat deze aangemaakt wordt.
        //De view wordt dan ook aangemaakt en dan kunnen er medewerkers worden toegevoegd. 
    }
}
