using JWM.Clinic.AccessData.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JWM.Repositories.Comum.Entity
{
    public class RepositoryGenericEntity<TEntity, TKey> : IRepositoryGeneric<TEntity, TKey>
        where TEntity : class
    {

        protected Contexto _contexto;

        public RepositoryGenericEntity(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Change(TEntity entity)
        {
            _contexto.Set<TEntity>().Attach(entity);
            _contexto.Entry(entity).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _contexto.Set<TEntity>().Remove(entity);
            _contexto.SaveChanges();
        }

        public void DeleteToId(TKey id)
        {
            TEntity entity = SelectionToId(id);
            Delete(entity);
        }

        public void Insert(TEntity entity)
        {
            _contexto.Set<TEntity>().Add(entity);
            _contexto.SaveChanges();
        }

        public virtual List<TEntity> Selection()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public TEntity SelectionToId(TKey id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }
    }
}
