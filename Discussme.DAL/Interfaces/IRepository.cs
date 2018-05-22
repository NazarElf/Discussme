using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discussme.DAL.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        //CRUD

        //Create
        void Create(TEntity item);
        Task CreateAsync(TEntity item);

        //Read
        Task<IEnumerable<TEntity>> ReadListAsync();
        IEnumerable<TEntity> ReadList();

        Task<IEnumerable<TEntity>> FindAllAsync(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> FindAll(Func<TEntity, bool> predicate);

        Task<TEntity> ReadItemByIdAsync(TKey id);
        TEntity ReadItemById(TKey id);

        //Update
        Task UpdateAsync(TEntity item);
        void Update(TEntity item);

        //Delete
        Task DeleteByIdAsync(TKey id);
        void DeleteById(TKey id);

        Task DeleteAsync(TEntity item);
        void Delete(TEntity item);
    }
}
