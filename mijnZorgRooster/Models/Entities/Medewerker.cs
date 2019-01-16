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

        //[Required, StringLength(40)]
        public String Voornaam { get; set; }

        //[Required, StringLength(40)]
        public String Achternaam { get; set; }

        public String Tussenvoegsels { get; set; }

        [StringLength(12)]
        public String Telefoonnummer { get; set; }

        //[Required, StringLength(12)]
        public String MobielNummer { get; set; }

        [Required, StringLength(40)]
        public String Emailadres { get; set; }

        //[Required, StringLength(100)]
        public String Adres { get; set; }

        //[Required, StringLength(6)]
        public String Postcode { get; set; }

        //[Required, StringLength(50)]
        public String Woonplaats { get; set; }

        //[Required, StringLength(10)]
        public DateTime Geboortedatum { get; set; }

        public ICollection<Contract> Contracten { get; set; }
        public ICollection<Certificaat> Certificaten { get; set; }
        public ICollection <MedewerkerRol> MedewerkersRollen { get; set; }

    }
}
