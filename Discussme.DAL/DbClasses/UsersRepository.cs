using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;

namespace Discussme.DAL.DbClasses
{
    public class UsersRepository : IRepository<User>
    {
        DbContextes.MainContext db;

        public UsersRepository(DbContextes.MainContext db) => this.db = db;

        public void Create(User item) => db.Users.Add(item);

        public void Delete(User item) => db.Users.Remove(item);

        public void DeleteById(int id) => db.Users.Remove(ReadItemById(id));

        public IEnumerable<User> FindAll(Func<User, bool> predicate) => db.Users.Where(predicate);

        public User ReadItemById(int id) => db.Users.Find(id);

        public IEnumerable<User> ReadList() => db.Users;

        public void Update(User item) => db.Entry(item).State = EntityState.Modified;
    }
}
