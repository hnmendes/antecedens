using antecedens.Domain.Interfaces.Repositories;
using JsonFlatFileDataStore;
using System;
using System.Collections.Generic;

namespace antecedens.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable,IRepositoryBase<TEntity> where TEntity : class
    {
        protected DataStore jsonDB = new DataStore("db.json");

        public void Add(TEntity entity)
        {
            jsonDB.GetCollection<TEntity>().InsertOne(entity);
        }        

        public IEnumerable<TEntity> GetAll()
        {
            var collection = jsonDB.GetCollection<TEntity>().AsQueryable();

            return collection;
        }

        public void Dispose()
        {
            jsonDB.Dispose();
        }
    }
}
