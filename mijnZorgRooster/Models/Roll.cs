using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace mijnZorgRooster.Models
{
    public class Roll
    {
        [Key]
        public int RolID { get; set; }
        //doen we dit als een model class in de database
        //of gebruiken we enums of een lijst.
    }
}
