using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Services.Comum
{
    public interface IServiceGeneric<TEntity, TKey>
        where TEntity : class
    {
        List<TEntity> Selection();
        TEntity SelectionToId(TKey id);
        void Insert(TEntity entity);
        void Change(TEntity entity);
        void Delete(TEntity entity);
        void DeleteToId(TKey id);

    }
}
