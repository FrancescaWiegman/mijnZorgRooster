using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.Services
{
	public class DienstService : IDienstService
	{
        public List<Dienst> GenereerDiensten(RoosterMetDienstProfielenDto rooster, List<int> dienstProfielen)
        {
            List<Dienst> huidigeDiensten = rooster.Diensten.ToList();

            List<Dienst> nieuweDiensten = filterVerwijderdeProfielen(huidigeDiensten, dienstProfielen);

            //TODO: ontbrekende profielen nog toevoegen.

            return new List<Dienst>();
        }

        private List<Dienst> filterVerwijderdeProfielen(List<Dienst> diensten, List<int> dienstProfielen)
        {
            List<Dienst> filteredDienstList = diensten.Where(d=>dienstProfielen.Contains(d.DienstProfiel.DienstProfielID)).ToList();

            return filteredDienstList;
        }


		public List<Dienst> GenereerDiensten(RoosterMetDienstProfielenDto roosterDto, List<DienstProfiel> dienstProfielen)
		{
			return GenereerMissendeDiensten(roosterDto.StartDatum, roosterDto.EindDatum, roosterDto, dienstProfielen);
		}

		private List<Dienst> GenereerMissendeDiensten(DateTime beginDatum, DateTime eindDatum, RoosterMetDienstProfielenDto roosterDto, List<DienstProfiel> dienstProfielen)
		{
			List<Dienst> diensten = new List<Dienst>();
			var selectedDienstProfielen = roosterDto.SelectedDienstProfielen;

            for (DateTime datum = beginDatum; datum.Date <= eindDatum.Date; datum = datum.AddDays(1))
            {
                if (!CheckOfDienstBestaat(roosterDto, datum, dienstProfielen))
                {
                    foreach (var selectedProfiel in selectedDienstProfielen)
                    {
                        Dienst nieuweDienst = new Dienst();
                        DienstProfiel profiel = ConvertIdToDienstProfiel(selectedProfiel, dienstProfielen);
                        nieuweDienst.Datum = datum;
                        nieuweDienst.DienstProfiel = profiel;
                        diensten.Add(nieuweDienst);
                    }
                }
            }
            return diensten;
		}

        private bool CheckOfDienstBestaat(RoosterMetDienstProfielenDto roosterDto, DateTime datum, List<DienstProfiel> dienstProfielen)
        {
            var dienstenLijst = roosterDto.Diensten;
            var selectedDienstProfielen = roosterDto.SelectedDienstProfielen;

            if (dienstenLijst == null) { return false; }
            foreach (Dienst d in dienstenLijst)
            {
                foreach (var dienstProfielID in selectedDienstProfielen)
                {
                    if (d.Datum == datum && d.DienstProfiel.DienstProfielID == dienstProfielID) return true;
                }
            }
            return false;
        }

        public DienstProfiel ConvertIdToDienstProfiel (int dienstProfielId, List<DienstProfiel> dienstProfielen)
		{
			DienstProfiel dienstProfiel = new DienstProfiel();
			foreach (var dp in dienstProfielen) { if (dp.DienstProfielID == dienstProfielId) dienstProfiel = dp; }
			return dienstProfiel;
		}
	}
}
