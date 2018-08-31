using JWM.Repositories.Comum;
using JWM.Services.Comum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JWM.Services
{
    public class ServiceBase<TEntity, TKey> : IServiceGeneric<TEntity, TKey>
        where TEntity : class
    {

        private readonly IRepositoryGeneric<TEntity, TKey> _repository;

        public ServiceBase(IRepositoryGeneric<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public void Change(TEntity entity)
        {
            _repository.Change(entity);

        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void DeleteToId(TKey id)
        {
            _repository.DeleteToId(id);
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public List<TEntity> Selection()
        {
           return _repository.Selection();
        }

        public TEntity SelectionToId(TKey id)
        {
           return _repository.SelectionToId(id);
        }
    }
}
