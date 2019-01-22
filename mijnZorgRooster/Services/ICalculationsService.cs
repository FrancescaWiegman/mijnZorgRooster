using System;
using System.Threading.Tasks;

namespace mijnZorgRooster.Services
{
    public interface ICalculationsService 
    {
        //int BerekenMaandenInDienst(int MedewerkerID);
        //double BerekenVakantieDagen(int MedewerkerID);

        int BerekenLeeftijdInJaren(DateTime geboortedatum);
        // Task<double> BerekenVakantieDagen(int MedewerkerID);

        //int BerekenParttimePercentage(int MedewerkerID);
    }
}
