using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
	public class DienstRepository : GenericRepository<Dienst>, IDienstRepository
	{
		public DienstRepository(ZorginstellingDbContext context) : base(context)
		{
            dbSet = _context.Set<Dienst>();
        }

		//TODO: Later uitbreiden met Medewerkersinformatie

		public async Task<DienstDto> GetDienstDto(int? dienstId)
		{
			List<DienstProfiel> dienstProfielen = await _context.DienstProfielen.ToListAsync();
			Dienst dienst = await _context.Diensten
				.Include(rp => rp.DienstProfiel)
				.Where(d => d.DienstID == dienstId)
				.SingleOrDefaultAsync();

			DienstDto dto = new DienstDto(dienst);
			if (dienst.Medewerkers == null)
			{
				dto.IngeroosterdeZorgverleners = 0;
				dto.Medewerkers = new List<Medewerker>();
			}
			else
			{
				dto.IngeroosterdeZorgverleners = dienst.Medewerkers.Count();
				dto.Medewerkers = dienst.Medewerkers;
			}
			return dto;
		}

		public async Task<List<DienstDto>> GetDienstenDto()
		{
            return await _context.Diensten
               .Include(d => d.DienstProfiel)
               .Select(d => new DienstDto(d))
               .ToListAsync();
		}

        public List<Dienst> GenereerDiensten(RoosterMetDienstProfielenDto rooster, List<int> dienstProfielen)
        {
            List<Dienst> huidigeDiensten = rooster.Diensten.ToList();
            List<Dienst> nieuweDiensten = VerwijderDienstenVanNietBestaandeProfielen(huidigeDiensten, dienstProfielen);

            foreach (int dienstProfielID in dienstProfielen)
            {
                if (!ZijnDienstenVoorProfielAangemaakt(nieuweDiensten, dienstProfielID))
                {
                    DienstProfiel profiel = rooster.DienstProfielOptions.Items.Cast<DienstProfiel>().Where(dp => dp.DienstProfielID == dienstProfielID).SingleOrDefault();

                    for (DateTime datum = rooster.StartDatum; datum.Date <= rooster.EindDatum.Date; datum = datum.AddDays(1))
                    {
                        Dienst dienst = new Dienst()
                        {
                            DienstProfiel = profiel,
                            Datum = datum
                        };

                        nieuweDiensten.Add(dienst);
                        dbSet.Add(dienst);
                    }
                }
            }

            return nieuweDiensten;
        }

        private List<Dienst> VerwijderDienstenVanNietBestaandeProfielen(List<Dienst> diensten, List<int> dienstProfielen)
        {
            List<Dienst> filteredDienstList = diensten.Where(d => dienstProfielen.Contains(d.DienstProfiel.DienstProfielID)).ToList();
            List<Dienst> teVerwijderenDiensten = diensten.Except(filteredDienstList).ToList();

            VerwijderDiensten(teVerwijderenDiensten);

            return filteredDienstList;
        }

        private void VerwijderDiensten(List<Dienst> diensten)
        {
            foreach (Dienst dienst in diensten)
            {
                dbSet.Remove(dienst);
            }
        }

        private bool ZijnDienstenVoorProfielAangemaakt(List<Dienst> diensten, int dienstProfielID)
        {
            foreach (Dienst dienst in diensten)
            {
                if (dienst.DienstProfiel.DienstProfielID == dienstProfielID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
