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

        public int BerekenVakantieDagen(int medewerkerID)
        {
            var medewerker = _medewerkerRepository.GetMedewerkerById(medewerkerID);
            var leeftijd = (DateTime.Now - medewerker.Geboortedatum);
            var contract = _medewerkerRepository.GetContractVoorMedewerker(DateTime.Now, medewerkerID);
            // TODO: Wat heeft leeftijd met vakantiedagen te maken?
            return 25 * contract.ParttimePercentage + ((int)leeftijd.TotalDays / 5) - 3;
        }
    }
}
