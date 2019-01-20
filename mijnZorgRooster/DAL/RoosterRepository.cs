using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
	public class RoosterRepository : GenericRepository<Rooster>, IRoosterRepository
	{
		public RoosterRepository(ZorginstellingDbContext context) : base(context)
		{
		}

        public async Task<List<RoosterBasisDto>> GetRoosters()
        {
            List<Rooster> roosters = await _context.Roosters
                .Include(r => r.RoosterDienstProfielen)
                .Include(r => r.Diensten)
                .ToListAsync();

            IEnumerable<RoosterBasisDto> dto = from rooster in roosters select new RoosterBasisDto(rooster)
            {
                AantalDiensten = rooster.Diensten.Count(),
                AantalDienstProfielen = rooster.RoosterDienstProfielen.Count()
            };

            return dto.OrderByDescending(d => d.Jaar).ThenByDescending(d => d.Maand).ToList();
        }

        public async Task<RoosterDetailDto> GetRoosterDetailDto(int? id)
        {
            Rooster rooster = await _context.Roosters
                .Include(r => r.RoosterDienstProfielen)
                .Include(r => r.Diensten).ThenInclude(d => d.DienstProfiel)
                .Where(r => r.RoosterID == id)
                .SingleOrDefaultAsync();

            RoosterDetailDto dto = new RoosterDetailDto(rooster)
            {
                AantalDiensten = rooster.Diensten.Count(),
                AantalDienstProfielen = rooster.RoosterDienstProfielen.Count()
            };

            List<Dienst> diensten = dto.Diensten.OrderBy(d => d.Datum).ThenBy(d => d.DienstProfiel.Begintijd).ToList();
            dto.Diensten = diensten;

            return dto;
        }

        public async Task<Rooster> GetRooster(int id)
        {
            return await _context.Roosters
                .Include(r => r.Diensten)
                .Where(r => r.RoosterID == id)
                .SingleOrDefaultAsync();

        }

        public async Task<RoosterMetDienstProfielenDto> GetRoosterMetDienstProfielenDto(int? roosterId)
		{
			List<DienstProfiel> dienstProfielen = await _context.DienstProfielen.ToListAsync();
			Rooster rooster = await _context.Roosters
				.Include(r => r.RoosterDienstProfielen)
                .Include(r => r.Diensten).ThenInclude(d => d.DienstProfiel)
                .Where(r => r.RoosterID == roosterId)
				.SingleOrDefaultAsync();

            RoosterMetDienstProfielenDto dto = new RoosterMetDienstProfielenDto(rooster)
            {
                AantalDiensten = rooster.Diensten.Count(),
                AantalDienstProfielen = rooster.RoosterDienstProfielen.Count(),
                SelectedDienstProfielen = rooster.RoosterDienstProfielen.Select(rdp => rdp.DienstProfielId).ToList(),
                DienstProfielOptions = new SelectList(dienstProfielen, nameof(DienstProfiel.DienstProfielID), nameof(DienstProfiel.Beschrijving))
            };

            return dto;
		}

		public async Task<Rooster> GetRoosterMetDienstProfielen(int? roosterId)
		{
			return await _context.Roosters
				.Include(r => r.RoosterDienstProfielen)
				.ThenInclude(d => d.DienstProfiel)
				.Where(r => r.RoosterID == roosterId)
				.SingleOrDefaultAsync();
		}

		public async Task UpdateRoosterDienstProfielen(int roosterId, List<int> selectedDienstProfielen)
		{
			Rooster rooster = await GetRoosterMetDienstProfielen(roosterId);
			rooster.RoosterDienstProfielen.Clear();

			foreach (int selectedDienstProfielId in selectedDienstProfielen)
			{
				DienstProfiel dienstprofiel = _context.DienstProfielen.Where(d => d.DienstProfielID == selectedDienstProfielId).SingleOrDefault();
				rooster.RoosterDienstProfielen.Add(new RoosterDienstProfiel()
				{
					Rooster = rooster,
					DienstProfiel = dienstprofiel,
				});
			}
		}

	}
}
