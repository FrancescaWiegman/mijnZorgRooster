using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.DAL.Repositories
{
    public class RolRepository : IRolRepository
    {
        internal ZorginstellingDbContext _context;

        public RolRepository(ZorginstellingDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolDTO>> GetAsync()
        {
            return await _context.Rollen.Select(r => new RolDTO(r)).ToListAsync();
        }

        public async Task<RolDTO> GetByIdAsync(int id)
        {
            return new RolDTO(await _context.Rollen.Where(r => r.RolID == id).SingleOrDefaultAsync());
        }

        public void Insert(Rol entity)
        {
            _context.Rollen.Add(entity);
        }

        public void Update(Rol entity)
        {
            _context.Rollen.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Rol entityToDelete = _context.Rollen.Find(id);
            _context.Rollen.Remove(entityToDelete);
        }
    }
}
