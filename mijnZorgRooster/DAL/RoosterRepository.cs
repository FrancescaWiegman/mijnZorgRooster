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

		public async Task<RoosterMetDienstProfielenDto> GetRoosterMetDienstProfielenDto(int? roosterId)
		{
			List<DienstProfiel> dienstProfielen = await _context.DienstProfielen.ToListAsync();
			RoosterMetDienstProfielenDto rooster = await _context.Roosters
				.Include(r => r.RoosterDienstProfielen)
				.ThenInclude(d => d.DienstProfiel)
				.Where(r => r.RoosterID == roosterId)
				.Select(r => new RoosterMetDienstProfielenDto()
				{
					RoosterID = r.RoosterID,
					Jaar = r.Jaar,
					Maand = r.Maand,
					AanmaakDatum = r.AanmaakDatum,
					LaatsteWijzigingsDatum = r.LaatsteWijzigingsDatum,
					IsGevalideerd = r.IsGevalideerd,
					SelectedDienstProfielen = r.RoosterDienstProfielen.Select(rdp => rdp.DienstProfielId).ToList(),
					DienstProfielOptions = new SelectList(dienstProfielen, nameof(DienstProfiel.DienstProfielID), nameof(DienstProfiel.Beschrijving)),
				})
				.SingleOrDefaultAsync();
			return rooster;
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

			foreach (var selectedDienstProfielId in selectedDienstProfielen)
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
