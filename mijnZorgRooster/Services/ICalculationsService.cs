

using System;
using System.Threading.Tasks;

namespace mijnZorgRooster.Services
{
    public interface ICalculationsService 
    {
        int BerekenMaandenInDienst(int MedewerkerID);
        double BerekenVakantieDagen(int MedewerkerID);

        Task<int> BerekenLeeftijdInJaren(int MedewerkerID);

    
    }
}
