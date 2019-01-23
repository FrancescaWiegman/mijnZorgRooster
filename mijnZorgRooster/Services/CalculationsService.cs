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
        const int fulltime = 36;

        public CalculationsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         
        }

        public int BerekenLeeftijdInJaren(DateTime geboortedatum)
        {
            int leeftijdInJaren = 0;
            DateTime vandaag = DateTime.Today;

            DateTime beginDatum = new DateTime(1, 1, 1);
            TimeSpan span = vandaag.Subtract(geboortedatum);
            leeftijdInJaren = (beginDatum + span).Year - 1;

            return leeftijdInJaren;
        }

        private int BerekenMaandenInDienst(ContractDTO contract)
        {
            int year = DateTime.Now.Year;
            DateTime lastDay = new DateTime(year, 12, 31);

            if (contract.Einddatum == DateTime.MinValue)
            {
                contract.Einddatum = lastDay;
            }

            return contract.Einddatum.Month - contract.BeginDatum.Month;
        }

        public int BerekenParttimePercentage(int contractUren)
        {
            return contractUren / fulltime * 100;
        }

        public double BerekenVakantieDagen(ContractDTO contract)
        {
            int maandenInDienst = BerekenMaandenInDienst(contract);
            var vakantieDagenFulltime = (maandenInDienst / 12 * vakantieUren) / 8;

            return vakantieDagenFulltime;
        }


    }
}
