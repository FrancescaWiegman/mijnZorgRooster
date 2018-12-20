using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int ContractUren { get; set; }

        public Medewerker Medewerker { get; set; }

        // Dit is wederom iets wat berekend moet worden. Dit moet ik nog even navragen voor ik Controllers, Views en databases met connectiestrings aan ga maken.
        public int verlofDagenPerJaar { get; set; }

        //Parttime percentage zou berekend moeten worden. Weet nog niet hoe
        public int ParttimePercentage { get; set; }

    }
}
