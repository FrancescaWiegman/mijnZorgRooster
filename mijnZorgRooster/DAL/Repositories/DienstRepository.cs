using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;

namespace mijnZorgRooster.DAL.Repositories
{
	public class DienstRepository : IDienstRepository
	{
        internal ZorginstellingDbContext _context;

        public DienstRepository(ZorginstellingDbContext context)
		{
            _context = context;
        }

		//TODO: Later uitbreiden met Medewerkersinformatie

		public async Task<DienstDTO> GetByIdAsync(int? dienstId)
		{
            return new DienstDTO(
                await _context.Diensten
                    .Include(rp => rp.DienstProfiel)
                    .Where(d => d.DienstID == dienstId)
                    .SingleOrDefaultAsync()
            );
		}

		public async Task<List<DienstDTO>> GetAsync()
		{
            return await _context.Diensten
               .Include(d => d.DienstProfiel)
               .Select(d => new DienstDTO(d))
               .ToListAsync();
		}

        public List<Dienst> GenereerDiensten(int roosterID, List<int> dienstProfielen)
        {
            Rooster rooster = _context.Roosters
                .Include(r => r.Diensten).ThenInclude(d => d.DienstProfiel)
                .Where(r => r.RoosterID == roosterID)
                .SingleOrDefault();

            RoosterDTO dto = new RoosterDTO(rooster);

            List<Dienst> huidigeDiensten = rooster.Diensten.ToList();
            List<Dienst> nieuweDiensten = VerwijderDienstenVanNietBestaandeProfielen(huidigeDiensten, dienstProfielen);

            foreach (int dienstProfielID in dienstProfielen)
            {
                if (!ZijnDienstenVoorProfielAangemaakt(nieuweDiensten, dienstProfielID))
                {
                    DienstProfiel profiel = _context.DienstProfielen.Where(dp => dp.DienstProfielID == dienstProfielID).SingleOrDefault();

                    for (DateTime datum = dto.StartDatum; datum.Date <= dto.EindDatum.Date; datum = datum.AddDays(1))
                    {
                        Dienst dienst = new Dienst()
                        {
                            DienstProfiel = profiel,
                            Datum = datum
                        };

                        nieuweDiensten.Add(dienst);
                        _context.Diensten.Add(dienst);
                    }
                }
            }

            return nieuweDiensten;
        }

        private List<Dienst> VerwijderDienstenVanNietBestaandeProfielen(List<Dienst> diensten, List<int> dienstProfielen)
        {
            List<Dienst> filteredDienstDTOList = diensten.Where(d => dienstProfielen.Contains(d.DienstProfiel.DienstProfielID)).ToList();
            List<Dienst> teVerwijderenDiensten = diensten.Except(filteredDienstDTOList).ToList();

            VerwijderDiensten(teVerwijderenDiensten);

            return filteredDienstDTOList;
        }

        private void VerwijderDiensten(List<Dienst> diensten)
        {
            foreach (Dienst dienst in diensten)
            {
                Delete(dienst.DienstID);
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

        public void Insert(Dienst entity)
        {
            _context.Diensten.Add(entity);
        }

        public void Update(Dienst entity)
        {
            _context.Diensten.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Dienst entityToDelete = _context.Diensten.Find(id);
            _context.Diensten.Remove(entityToDelete);
        }
    }
}
