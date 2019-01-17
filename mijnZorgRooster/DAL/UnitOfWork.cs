using mijnZorgRooster.Models.Entities;
using System;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ZorginstellingDbContext _context;
        public IMedewerkerRepository MedewerkerRepository { get; private set; }
        public IGenericRepository<DienstProfiel> DienstProfielRepository { get; private set; }
        public IDienstRepository DienstRepository { get; private set; }
        public IRoosterRepository RoosterRepository { get; private set; }
        public IGenericRepository<Rol> RolRepository { get; private set; }
        public IGenericRepository<Certificaat> CertificaatRepository { get; private set; }
        public IGenericRepository<Contract> ContractRepository { get; private set; }

        public UnitOfWork(ZorginstellingDbContext context)
        {
            _context = context;
            MedewerkerRepository = new MedewerkerRepository(context);
            DienstProfielRepository = new GenericRepository<DienstProfiel>(context);
            DienstRepository = new DienstRepository(context);
            RoosterRepository = new RoosterRepository(context);
            RolRepository = new GenericRepository<Rol>(context);
            CertificaatRepository = new GenericRepository<Certificaat>(context);
            ContractRepository = new GenericRepository<Contract>(context);
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
