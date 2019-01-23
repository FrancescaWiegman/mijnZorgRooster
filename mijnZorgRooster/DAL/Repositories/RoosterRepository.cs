using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL.Repositories
{
	public class RoosterRepository : IRoosterRepository
	{
        internal ZorginstellingDbContext _context;

        public RoosterRepository(ZorginstellingDbContext context)
		{
            this._context = context;
        }

        public async Task<List<RoosterDTO>> GetAsync()
        {
            List<Rooster> roosters = await _context.Roosters
                .Include(r => r.RoosterDienstProfielen)
                .Include(r => r.Diensten).ThenInclude(d => d.DienstProfiel)
                .ToListAsync();

            IEnumerable<RoosterDTO> roosterDTO = from rooster in roosters select new RoosterDTO(rooster)
            {
                AantalDiensten = rooster.Diensten.Count(),
                AantalDienstProfielen = rooster.RoosterDienstProfielen.Count(),
                Diensten = from dienst in rooster.Diensten select new DienstDTO(dienst)
            };

            return roosterDTO.OrderByDescending(d => d.Jaar).ThenByDescending(d => d.Maand).ToList();
        }

        public async Task<RoosterDTO> GetByIdAsync(int id)
        {
            Rooster rooster = await _context.Roosters
                .Include(r => r.RoosterDienstProfielen)
                .Include(r => r.Diensten).ThenInclude(d => d.DienstProfiel)
                .Where(r => r.RoosterID == id)
                .SingleOrDefaultAsync();

            RoosterDTO roosterDTO = new RoosterDTO(rooster)
            {
                AantalDiensten = rooster.Diensten.Count(),
                AantalDienstProfielen = rooster.RoosterDienstProfielen.Count(),
                Diensten = from dienst in rooster.Diensten select new DienstDTO(dienst)
            };

            List<DienstDTO> diensten = roosterDTO.Diensten.OrderBy(d => d.Datum).ThenBy(d => d.Begintijd).ToList();
            roosterDTO.Diensten = diensten;

            return roosterDTO;

        }

        public async Task<RoosterMetDienstProfielenDTO> GetRoosterMetDienstProfielenDto(int? roosterId)
		{
			List<DienstProfiel> dienstProfielen = await _context.DienstProfielen.ToListAsync();
			Rooster rooster = await _context.Roosters
				.Include(r => r.RoosterDienstProfielen)
                .Include(r => r.Diensten).ThenInclude(d => d.DienstProfiel)
                .Where(r => r.RoosterID == roosterId)
				.SingleOrDefaultAsync();

            RoosterMetDienstProfielenDTO dto = new RoosterMetDienstProfielenDTO(rooster)
            {
                AantalDiensten = rooster.Diensten.Count(),
                AantalDienstProfielen = rooster.RoosterDienstProfielen.Count(),
                SelectedDienstProfielen = rooster.RoosterDienstProfielen.Select(rdp => rdp.DienstProfielId).ToList(),
                RoosterDienstProfielen = rooster.RoosterDienstProfielen,
                DienstProfielOptions = new SelectList(dienstProfielen, nameof(DienstProfiel.DienstProfielID), nameof(DienstProfiel.Beschrijving))
            };

            return dto;
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

        private async Task<Rooster> GetRoosterMetDienstProfielen(int? roosterId)
        {
            return await _context.Roosters
                .Include(r => r.RoosterDienstProfielen)
                .ThenInclude(d => d.DienstProfiel)
                .Where(r => r.RoosterID == roosterId)
                .SingleOrDefaultAsync();
        }

        public void Insert(Rooster entity)
        {
            _context.Roosters.Add(entity);
        }

        public void Delete(int id)
        {
            Rooster entityToDelete = _context.Roosters.Find(id);
            _context.Roosters.Remove(entityToDelete);
        }

        public void Update(Rooster entity)
        {
            _context.Roosters.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
