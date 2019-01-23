using mijnZorgRooster.Models.Entities;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public interface IUnitOfWork
    {
        IMedewerkerRepository MedewerkerRepository { get; }
		IGenericRepository<DienstProfiel> DienstProfielRepository { get; }
		IDienstRepository DienstRepository { get; }
		IRoosterRepository RoosterRepository { get; }
        IGenericRepository<Rol> RolRepository { get; }
        IGenericRepository<Contract> ContractRepository { get; }
        IGenericRepository<Certificaat> CertificaatRepository { get; }
        object IGenericRepository { get; }

        Task SaveAsync();
        void Save();
        void Dispose();
    }
}
