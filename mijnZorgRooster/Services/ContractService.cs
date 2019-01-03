using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Services
{
    public class ContractService : IContractService
    {
        private IMedewerkerRepository _medewerkerRepository;

        public ContractService(IMedewerkerRepository medewerkerRepository)
        {
            _medewerkerRepository = medewerkerRepository;
        }
        public int BerekenParttimePercentage(int MedewerkerID)
        {
            var medewerker = _medewerkerRepository.GetMedewerkerById(MedewerkerID);
            var contract = _medewerkerRepository.GetContractForEmployee(DateTime.Now, MedewerkerID);
            var fulltime = 36;
            var ParttimePercentage = contract.ContractUren / fulltime * 100;

            return ParttimePercentage;

        }

       
    }
}
