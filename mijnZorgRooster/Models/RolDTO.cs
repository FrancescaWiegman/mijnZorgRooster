using mijnZorgRooster.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models
{
    public class RolDTO
    {
        public RolDTO()
        {
        }

        public RolDTO(Rol rol)
        {
            RolID = rol.RolID;
            Naam = rol.Naam;
        }
        public int RolID { get; set; }
        public string Naam { get; set; }
    }
}
