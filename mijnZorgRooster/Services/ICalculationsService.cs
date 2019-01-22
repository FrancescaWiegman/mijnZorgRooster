using mijnZorgRooster.Models;
using System;
using System.Threading.Tasks;

namespace mijnZorgRooster.Services
{
    public interface ICalculationsService 
    {
        int BerekenLeeftijdInJaren(DateTime geboortedatum);
        double BerekenVakantieDagen(ContractDTO contract);
        int BerekenParttimePercentage(int contractUren);
    }
}
