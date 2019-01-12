using mijnZorgRooster.Models.Entities;
using System;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ZorginstellingDbContext _context;
        private IMedewerkerRepository _medewerkerRepository;
		// private IGenericRepository<Medewerker> _medewerkerRepository;
		private IDienstProfielRepository _dienstProfielRepository;
		private IDienstRepository _dienstRepository;
		private IRoosterRepository _roosterRepository;

		public UnitOfWork(ZorginstellingDbContext context)
        {
            _context = context;
        }

        public IMedewerkerRepository MedewerkerRepository
        {
            get { return _medewerkerRepository ?? (_medewerkerRepository = new MedewerkerRepository(_context)); }
        }

		public IDienstProfielRepository DienstProfielRepository
		{
			get { return _dienstProfielRepository ?? (_dienstProfielRepository = new DienstProfielRepository(_context)); }
		}

		public IDienstRepository DienstRepository
		{
			get { return _dienstRepository ?? (_dienstRepository = new DienstRepository(_context)); }
		}

		public IRoosterRepository RoosterRepository
		{
			get { return _roosterRepository ?? (_roosterRepository = new RoosterRepository(_context)); }
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
