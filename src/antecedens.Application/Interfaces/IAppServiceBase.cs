
using System.Collections.Generic;

namespace antecedens.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> GetAll();

        void Dispose();

    }
}
