using mijnZorgRooster.Models.Entities;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public interface IUnitOfWork
    {
        IMedewerkerRepository MedewerkerRepository { get; }
 		    IDienstProfielRepository DienstProfielRepository { get; }
		    IDienstRepository DienstRepository { get; }
		    IRoosterRepository RoosterRepository { get; }
        IGenericRepository<Rol> RolRepository { get; }
        IGenericRepository<Certificaat> CertificaatRepository { get; }
        Task SaveAsync();
        void Save();
        void Dispose();
    }
}
