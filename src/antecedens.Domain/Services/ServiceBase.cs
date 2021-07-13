using antecedens.Domain.Interfaces.Repositories;
using antecedens.Domain.Interfaces.Services;
using System.Linq;
using System.Collections.Generic;
using System;

namespace antecedens.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
