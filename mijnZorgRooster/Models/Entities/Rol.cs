using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace mijnZorgRooster.Models
{
    public class Rol
    {
        public int RolID { get; set; }
        public string Naam { get; set; }
        //doen we dit als een model class in de database
        //of gebruiken we enums of een lijst.
    }
}
