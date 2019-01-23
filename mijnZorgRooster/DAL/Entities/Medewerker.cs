using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.DAL.Entities
{
    public class Medewerker
    {
        [Key]
        [ScaffoldColumn(false)]
        public int MedewerkerID { get; set; }

        //[Required, StringLength(40)]
        public string Voornaam { get; set; }

        //[Required, StringLength(40)]
        public string Achternaam { get; set; }

        public string Tussenvoegsels { get; set; }

        [StringLength(12)]
        public string Telefoonnummer { get; set; }

        //[Required, StringLength(12)]
        public string MobielNummer { get; set; }

        [Required, StringLength(40)]
        public string Emailadres { get; set; }

        //[Required, StringLength(100)]
        public string Adres { get; set; }

        //[Required, StringLength(6)]
        public string Postcode { get; set; }

        //[Required, StringLength(50)]
        public string Woonplaats { get; set; }

        //[Required, StringLength(10)]
        public DateTime Geboortedatum { get; set; }

        public ICollection<Contract> Contracten { get; set; }
        public ICollection<Certificaat> Certificaten { get; set; }
        public ICollection <MedewerkerRol> MedewerkersRollen { get; set; }

    }
}
