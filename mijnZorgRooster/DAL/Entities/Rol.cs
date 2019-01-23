using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.DAL.Entities
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public string Naam { get; set; }

        public ICollection<MedewerkerRol> MedewerkersRollen { get; set; }
    }

    public class MedewerkerRol
    {
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public int MedewerkerId { get; set; }
        public Medewerker Medewerker { get; set; }
    }
}
