using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models.Entities
{
    public class Rol
    {
        [Key]
        public int RollID { get; set; }
        public string Naam { get; set; }
    }
}
