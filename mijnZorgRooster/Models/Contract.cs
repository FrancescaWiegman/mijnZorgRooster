using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models
{
    public class Contract
    {
        //private Contract _contract;

        public int ContractID { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int ContractUren { get; set; }

        public Medewerker Medewerker { get; set; }

        [NotMapped]
        public ICollection<Medewerker> Medewerkers { get; set; }
        


    }
}
