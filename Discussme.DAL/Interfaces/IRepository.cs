using System;
using System.Collections.Generic;

namespace Discussme.DAL.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        //CRUD

        //Create
        void Create(TEntity item);

        //Read
        IEnumerable<TEntity> ReadList();
        IEnumerable<TEntity> FindAll(Func<TEntity, bool> predicate);
        TEntity ReadItemById(TKey id);

        //Update
        void Update(TEntity item);

        //Delete
        void DeleteById(TKey id);
        void Delete(TEntity item);
    }
}
