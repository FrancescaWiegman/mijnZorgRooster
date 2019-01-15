using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models.DTO
{
    public class ContractDetailDto
    {
   
        public int ContractID { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int ContractUren { get; set; }

        public int BerekenParttimePercentage { get; set; }
        public double BerekenVakantieDagen { get; set; }

    }
}
