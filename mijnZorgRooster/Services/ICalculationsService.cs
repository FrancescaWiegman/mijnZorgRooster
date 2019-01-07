

using System;

namespace mijnZorgRooster.Services
{
    public interface ICalculationsService 
    {
        int BerekenMaandenInDienst(int MedewerkerID);
        double BerekenVakantieDagen(int MedewerkerID);

        int BerekenLeeftijdInJaren(int MedewerkerID);

    
    }
}
