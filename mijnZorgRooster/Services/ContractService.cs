using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL;

namespace mijnZorgRooster.Services
{
    public class ContractService : IContractService
    {
        const int fulltime = 36;
        private readonly IUnitOfWork _unitOfWork;

        public ContractService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int BerekenParttimePercentage(int medewerkerID)
        {
            var medewerker = _unitOfWork.MedewerkerRepository.GetByIdAsync(medewerkerID);
            var contract = _unitOfWork.MedewerkerRepository.GetContractVoorMedewerker(DateTime.Now, medewerkerID);

            return contract.ContractUren / fulltime * 100;
        }

       
    }
}
