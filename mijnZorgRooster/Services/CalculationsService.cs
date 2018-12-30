using System;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Services
{
    public class CalculationsService : ICalculationsService
    {
        private IMedewerkerRepository _medewerkerRepository;

        public CalculationsService(IMedewerkerRepository medewerkerRepository)
        {
            _medewerkerRepository = medewerkerRepository;
        }

        public int BerekenVakantieDagen(int MedewerkerID)
        {
            int vakantieDagen;
            var medewerker = _medewerkerRepository.GetMedewerkerById(MedewerkerID);
            var leeftijd = (DateTime.Now - medewerker.Geboortedatum);
            var contract = _medewerkerRepository.GetContractForEmployee(DateTime.Now, MedewerkerID);
            vakantieDagen = 25 * contract.ParttimePercentage + ((int)leeftijd.TotalDays / 5) - 3;
            return vakantieDagen;         
            
        }

       
        
    }
}
