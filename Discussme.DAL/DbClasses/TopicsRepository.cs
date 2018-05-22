using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;
using System.Threading.Tasks;

namespace Discussme.DAL.DbClasses
{
    public class TopicsRepository : IRepository<Topic, int>
    {
        DbContextes.MainContext db;

        public TopicsRepository(DbContextes.MainContext db) => this.db = db;

        public void Create(Topic item)
        {
            db.Topics.Add(item);
            db.SaveChangesAsync();
        }

        public async Task CreateAsync(Topic item)
        {
            await Task.Run(() => db.Topics.Add(item));
            await db.SaveChangesAsync();
        }

        public void Delete(Topic item) => db.Topics.Remove(item);

        public async Task DeleteAsync(Topic item)
        {
            await Task.Run(() => db.Topics.Remove(item));
            await db.SaveChangesAsync();
        }

        public void DeleteById(int id) => db.Topics.Remove(ReadItemById(id));

        public async Task DeleteByIdAsync(int id)
        {
            await Task.Run(async () => db.Topics.Remove(await ReadItemByIdAsync(id)));
            await db.SaveChangesAsync();
        }

        public IEnumerable<Topic> FindAll(Func<Topic, bool> predicate) => db.Topics.Where(predicate);

        public async Task<IEnumerable<Topic>> FindAllAsync(Func<Topic, bool> predicate) => await Task.Run<IEnumerable<Topic>>(() => db.Topics.Where(predicate)); 

        public Topic ReadItemById(int id) => db.Topics.Find(id);

        public async Task<Topic> ReadItemByIdAsync(int id)
            => await Task.Run<Topic>(() => db.Topics.Find(id));

        public IEnumerable<Topic> ReadList() => db.Topics;

        public async Task<IEnumerable<Topic>> ReadListAsync()
            => await Task.Run<IEnumerable<Topic>>(() => db.Topics);

        public void Update(Topic item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public async Task UpdateAsync(Topic item)
        {
            await Task.Run(() => db.Entry(item).State = EntityState.Modified);
            await db.SaveChangesAsync();
        }
    }
}
