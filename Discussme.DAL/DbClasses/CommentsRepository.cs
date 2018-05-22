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
    public class CommentsRepository : IRepository<Comment, int>
    {
        DbContextes.MainContext db;

        public CommentsRepository(DbContextes.MainContext db) => this.db = db;


        public void Create(Comment item)
        {
            db.Comments.Add(item);
            db.SaveChangesAsync();
        }

        public async Task CreateAsync(Comment item)
        {
            await Task.Run(() =>
            {
                db.Comments.Add(item);
                db.SaveChangesAsync();
            });
        }

        public void Delete(Comment item)
        {
            db.Comments.Remove(item);
            db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment item)
        {
            await Task.Run(() =>
            {
                db.Comments.Remove(item);
                db.SaveChangesAsync();
            });
        }

        public void DeleteById(int id)
        {
            db.Comments.Remove(ReadItemById(id));
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Task.Run(async () => 
            {
                db.Comments.Remove(await ReadItemByIdAsync(id));
                await db.SaveChangesAsync();
            });
        }

        public IEnumerable<Comment> FindAll(Func<Comment, bool> predicate) => db.Comments.Where(predicate);

        public async Task<IEnumerable<Comment>> FindAllAsync(Func<Comment, bool> predicate) 
            => await Task.Run<IEnumerable<Comment>>(() => db.Comments.Where(predicate));

        public Comment ReadItemById(int id) => db.Comments.Find(id);

        public async Task<Comment> ReadItemByIdAsync(int id)
            => await Task.Run<Comment>(() => db.Comments.Find(id));

        public IEnumerable<Comment> ReadList() => db.Comments;

        public async Task<IEnumerable<Comment>> ReadListAsync()
            => await Task.Run<IEnumerable<Comment>>(() => db.Comments);

        public void Update(Comment item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment item)
        {
            await Task.Run(() => db.Entry(item).State = EntityState.Modified);
            await db.SaveChangesAsync();
        }
    }
}
