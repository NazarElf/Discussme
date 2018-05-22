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
    public class UsersRepository : IRepository<User, string>
    {
        DbContextes.MainContext db;

        public UsersRepository(DbContextes.MainContext db) => this.db = db;

        public void Create(User item)
        {
            db.MyUsers.Add(item);
            db.SaveChanges();
        }

        public async Task CreateAsync(User item)
        {
            await Task.Run(() => db.MyUsers.Add(item));
            await db.SaveChangesAsync();
        }

        public void Delete(User item)
        {
            db.MyUsers.Remove(item);
            db.SaveChanges();
        }

        public async Task DeleteAsync(User item)
        {
            await Task.Run(() => db.MyUsers.Remove(item));
            await db.SaveChangesAsync();
        }

        public void DeleteById(string id)
        {
            db.MyUsers.Remove(ReadItemById(id));
            db.SaveChanges();
        }

        public async Task DeleteByIdAsync(string id)
        {
            await Task.Run(async () => db.MyUsers.Remove(await ReadItemByIdAsync(id)));
            await db.SaveChangesAsync();
        }

        public IEnumerable<User> FindAll(Func<User, bool> predicate) 
            => db.MyUsers.Where(predicate);

        public async Task<IEnumerable<User>> FindAllAsync(Func<User, bool> predicate)
            => await Task.Run<IEnumerable<User>>(() => db.MyUsers.Where(predicate));

        public User ReadItemById(string id) 
            => db.MyUsers.Find(id);

        public async Task<User> ReadItemByIdAsync(string id)
            => await Task.Run<User>(() => db.MyUsers.Find(id));

        public IEnumerable<User> ReadList() 
            => db.MyUsers;

        public async Task<IEnumerable<User>> ReadListAsync()
            => await Task.Run<IEnumerable<User>>(() => db.MyUsers);

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public async Task UpdateAsync(User item)
        {
            await Task.Run(() => db.Entry(item).State = EntityState.Modified);
            await db.SaveChangesAsync();
        }
    }
}
