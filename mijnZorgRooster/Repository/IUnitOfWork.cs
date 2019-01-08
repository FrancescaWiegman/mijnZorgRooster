using System.Threading.Tasks;

namespace mijnZorgRooster.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void RejectChanges();
    }
}