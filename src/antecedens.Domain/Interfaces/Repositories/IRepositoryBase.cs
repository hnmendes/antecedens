using System.Collections.Generic;

namespace antecedens.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {        
        void Add(TEntity entity);
        
        IEnumerable<TEntity> GetAll();

        void Dispose();
    }
}
