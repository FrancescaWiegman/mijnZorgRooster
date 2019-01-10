using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public interface IGenericRepository<TEntity>
    {
        Task<IList<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);

    }
}
