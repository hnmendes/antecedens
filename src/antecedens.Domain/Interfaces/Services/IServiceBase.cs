using System;
using System.Collections.Generic;
using System.Text;

namespace antecedens.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> GetAll();

        void Dispose();
    }
}
