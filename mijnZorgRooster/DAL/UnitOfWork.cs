using mijnZorgRooster.Models.Entities;
using System;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ZorginstellingDbContext _context;
        private IMedewerkerRepository _medewerkerRepository;
        private IGenericRepository<Rol> _rolRepository;
        private IGenericRepository<Certificaat> _certficaatRepository;

        public UnitOfWork(ZorginstellingDbContext context)
        {
            _context = context;
        }

        public IMedewerkerRepository MedewerkerRepository
        {
            get { return _medewerkerRepository ?? (_medewerkerRepository = new MedewerkerRepository(_context)); }
        }

        public IGenericRepository<Rol> RolRepository
        {
            get { return _rolRepository ?? (_rolRepository = new GenericRepository<Rol>(_context)); }
        }

        public IGenericRepository<Certificaat> CertificaatRepository
        {
            get { return _certficaatRepository ?? (_certficaatRepository = new GenericRepository<Certificaat>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
