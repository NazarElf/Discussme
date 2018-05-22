using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;

namespace Discussme.DAL.DbClasses
{
    public class UsersRepository : IRepository<User, string>
    {
        DbContextes.MainContext db;

        public UsersRepository(DbContextes.MainContext db) => this.db = db;

        public void Create(User item) => db.MyUsers.Add(item);

        public void Delete(User item) => db.MyUsers.Remove(item);

        public void DeleteById(string id) => db.MyUsers.Remove(ReadItemById(id));

        public IEnumerable<User> FindAll(Func<User, bool> predicate) => db.MyUsers.Where(predicate);

        public User ReadItemById(string id) => db.MyUsers.Find(id);

        public IEnumerable<User> ReadList() => db.MyUsers;

        public void Update(User item) => db.Entry(item).State = EntityState.Modified;
    }
}
