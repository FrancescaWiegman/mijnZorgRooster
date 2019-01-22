using System;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.DAL.Entities
{
    public class Contract
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ContractID { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int ContractUren { get; set; }

        public Medewerker Medewerker { get; set; }
    }
}
