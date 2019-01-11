using System;
using System.Threading.Tasks;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL;

namespace mijnZorgRooster.Services
{
    public class CalculationsService : ICalculationsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly double vakantieUren = 237.4;
        private int maandenInDienst;

        public CalculationsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public double BerekenVakantieDagen(int MedewerkerID)
        //{
        //    double vakantieDagen;
        //    var medewerker = _medewerkerRepository.GetMedewerkerById(MedewerkerID);
        //    var LeeftijdInJaren = (DateTime.Now - medewerker.Geboortedatum);
        //    var contract = _medewerkerRepository.GetContractForEmployee(DateTime.Now, MedewerkerID);
        //    vakantieDagen = 25 * contract.ParttimePercentage + ((int)LeeftijdInJaren.TotalDays / 5) - 3;
        //    return vakantieDagen;         
            
        //}

        public async Task<int> BerekenLeeftijdInJaren(int medewerkerID)
        { 
            var leeftijdInJaren = 0;
            var medewerker = await _unitOfWork.MedewerkerRepository.GetByIdAsync(medewerkerID);
            var today = DateTime.Today;

            if (medewerker.Geboortedatum.Month > today.Month)
            {
                leeftijdInJaren = (today.Year - medewerker.Geboortedatum.Year) - 1;
            }
            else
            {
                leeftijdInJaren = today.Year - medewerker.Geboortedatum.Year;
            }
            return leeftijdInJaren;

        }
        public int BerekenMaandenInDienst(int medewerkerID)
        {
            int year = DateTime.Now.Year;
            DateTime lastDay = new DateTime(year, 12, 31);
            var contract = _unitOfWork.MedewerkerRepository.GetContractVoorMedewerker(DateTime.Now, medewerkerID);
            
            if(contract.Einddatum == DateTime.MinValue)
            {
                contract.Einddatum = lastDay;
            }

            maandenInDienst = contract.Einddatum.Month - contract.BeginDatum.Month;
            return maandenInDienst;
        }

        
        public double BerekenVakantieDagen(int medewerkerID)
        {
            //TODO: medewerker wordt niet gebruikt.
            var medewerker = _unitOfWork.MedewerkerRepository.GetByIdAsync(medewerkerID);
    
            return (maandenInDienst / 12 * vakantieUren)/8;
        }


    }
}
