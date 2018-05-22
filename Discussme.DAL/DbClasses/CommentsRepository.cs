using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;

namespace Discussme.DAL.DbClasses
{
    public class CommentsRepository : IRepository<Comment, int>
    {
        DbContextes.MainContext db;

        public CommentsRepository(DbContextes.MainContext db) => this.db = db;

        public void Create(Comment item) => db.Comments.Add(item);

        public void Delete(Comment item) => db.Comments.Remove(item);

        public void DeleteById(int id) => db.Comments.Remove(ReadItemById(id));

        public IEnumerable<Comment> FindAll(Func<Comment, bool> predicate) => db.Comments.Where(predicate);

        public Comment ReadItemById(int id) => db.Comments.Find(id);

        public IEnumerable<Comment> ReadList() => db.Comments;

        public void Update(Comment item) => db.Entry(item).State = EntityState.Modified;
    }
}
