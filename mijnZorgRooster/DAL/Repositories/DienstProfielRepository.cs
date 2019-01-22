using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.DAL.Repositories
{
    public class DienstProfielRepository : IDienstProfielRepository
    {
        internal ZorginstellingDbContext _context;

        public DienstProfielRepository(ZorginstellingDbContext context)
        {
            _context = context;
        }

        public async Task<List<DienstProfielDTO>> GetAsync()
        {
            return await _context.DienstProfielen.Select(dp => new DienstProfielDTO(dp)).ToListAsync();
        }

        public async Task<DienstProfielDTO> GetByIdAsync(int id)
        {
            return new DienstProfielDTO(await _context.DienstProfielen.Where(dp => dp.DienstProfielID == id).SingleOrDefaultAsync());
        }

        public void Insert(DienstProfiel entity)
        {
            _context.DienstProfielen.Add(entity);
        }

        public void Update(DienstProfiel entity)
        {
            _context.DienstProfielen.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DienstProfiel entityToDelete = _context.DienstProfielen.Find(id);
            _context.DienstProfielen.Remove(entityToDelete);
        }
    }
}
