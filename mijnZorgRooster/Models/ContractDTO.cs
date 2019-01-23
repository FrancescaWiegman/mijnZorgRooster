using mijnZorgRooster.DAL.Entities;
using System;

namespace mijnZorgRooster.Models
{
    public class ContractDTO
    {
        public ContractDTO(Contract contract)
        {
            ContractID = contract.ContractID;
            BeginDatum = contract.BeginDatum;
            Einddatum = contract.Einddatum;
            ContractUren = contract.ContractUren;
        }

        public int ContractID { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int ContractUren { get; set; }
        public MedewerkerDTO Medewerker { get; set; }

        public int ParttimePercentage { get; set; }
        public double VakantieDagen { get; set; }

    }
}
