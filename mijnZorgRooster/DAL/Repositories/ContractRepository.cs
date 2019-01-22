using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.DAL.Repositories
{
    public class ContractRepository : IContractRepository
    {
        internal ZorginstellingDbContext _context;

        public ContractRepository(ZorginstellingDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContractDTO>> GetAsync()
        {
            return await _context.Contracten.Select(c => new ContractDTO(c)).ToListAsync();
        }

        public async Task<ContractDTO> GetByIdAsync(int id)
        {
            return new ContractDTO(await _context.Contracten.Where(r => r.ContractID == id).SingleOrDefaultAsync());
        }

        public void Insert(Contract entity)
        {
            _context.Contracten.Add(entity);
        }

        public void Update(Contract entity)
        {
            _context.Contracten.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Contract entityToDelete = _context.Contracten.Find(id);
            _context.Contracten.Remove(entityToDelete);
        }
    }
}
