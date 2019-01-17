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

		public async Task<Dienst> GetDienstenMetAlleInfo(int? dienstId)
		{
			return await _context.Diensten
			   .Include(rp => rp.DienstProfiel)
			   .Where(d => d.DienstID == dienstId)
			   .SingleOrDefaultAsync();
		}
	}
}
