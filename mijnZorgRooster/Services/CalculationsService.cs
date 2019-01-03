using System;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Services
{
    public class CalculationsService : ICalculationsService
    {
        private IMedewerkerRepository _medewerkerRepository;
        private int LeeftijdInJaren;
        private readonly double vakantieUren = 237.4;
        private int MaandenInDienst;

        public CalculationsService(IMedewerkerRepository medewerkerRepository)
        {
            _medewerkerRepository = medewerkerRepository;
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

        public int BerekenLeeftijdInJaren(int MedewerkerID)
        { //berekening klopt niet. moet op dag,maand, jaar
            var medewerker = _medewerkerRepository.GetMedewerkerById(MedewerkerID);
            var today = DateTime.Today;
            LeeftijdInJaren = today.Year - medewerker.Geboortedatum.Year;
            return LeeftijdInJaren;

        }
        public int BerekenMaandenInDienst(int MedewerkerID)
        {
            int year = DateTime.Now.Year;
            DateTime lastDay = new DateTime(year, 12, 31);
            var contract = _medewerkerRepository.GetContractForEmployee(DateTime.Now, MedewerkerID);
            
            if(contract.Einddatum == DateTime.MinValue)
            {
                contract.Einddatum = lastDay;
            }

             MaandenInDienst = contract.Einddatum.Month - contract.BeginDatum.Month;
            return MaandenInDienst;
        }

        
        public double BerekenVakantieDagen(int MedewerkerID)
        {
            var medewerker = _medewerkerRepository.GetMedewerkerById(MedewerkerID);
            var Vakantiedagen = (MaandenInDienst / 12 * vakantieUren)/8;
            return Vakantiedagen;
           

        }


    }
}
