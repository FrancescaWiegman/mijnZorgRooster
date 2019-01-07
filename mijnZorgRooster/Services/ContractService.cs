using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models;
using mijnZorgRooster.Repository;

namespace mijnZorgRooster.Services
{
    public class ContractService : IContractService
    {
        const int fulltime = 36;
        private IMedewerkerRepository _medewerkerRepository;

        public ContractService(IMedewerkerRepository medewerkerRepository)
        {
            _medewerkerRepository = medewerkerRepository;
        }

        public int BerekenParttimePercentage(int medewerkerID)
        {
            var medewerker = _medewerkerRepository.GetMedewerkerById(medewerkerID);
            var contract = _medewerkerRepository.GetContractVoorMedewerker(DateTime.Now, medewerkerID);

            return contract.ContractUren / fulltime * 100;
        }

       
    }
}
