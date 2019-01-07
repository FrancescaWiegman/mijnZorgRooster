using System;
using mijnZorgRooster.Models;
using mijnZorgRooster.Repository;

namespace mijnZorgRooster.Services
{
    public class CalculationsService : ICalculationsService
    {
        private IMedewerkerRepository _medewerkerRepository;
        private int leeftijdInJaren;
        private readonly double vakantieUren = 237.4;
        private int maandenInDienst;

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

        public int BerekenLeeftijdInJaren(int medewerkerID)
        { //berekening klopt niet. moet op dag,maand, jaar
            var medewerker = _medewerkerRepository.GetMedewerkerById(medewerkerID);
            var today = DateTime.Today;
            leeftijdInJaren = today.Year - medewerker.Geboortedatum.Year;
            return leeftijdInJaren;

        }
        public int BerekenMaandenInDienst(int medewerkerID)
        {
            int year = DateTime.Now.Year;
            DateTime lastDay = new DateTime(year, 12, 31);
            var contract = _medewerkerRepository.GetContractVoorMedewerker(DateTime.Now, medewerkerID);
            
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
            var medewerker = _medewerkerRepository.GetMedewerkerById(medewerkerID);
    
            return (maandenInDienst / 12 * vakantieUren)/8;
        }


    }
}
