using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Save();
        void Dispose();
    }
}
