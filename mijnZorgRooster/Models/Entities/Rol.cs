using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models.Entities
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public string Naam { get; set; }
    }
}
