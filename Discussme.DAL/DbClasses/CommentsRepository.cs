using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;

namespace Discussme.DAL.DbClasses
{
    class CommentsRepository : IRepository<Comment>
    {
        MainContext db;

        public CommentsRepository(MainContext db) => this.db = db;

        public void Create(Comment item) => db.Comments.Add(item);

        public void DeleteById(int id) => db.Comments.Remove(ReadItemById(id));

        public IEnumerable<Comment> FindAll(Func<Comment, bool> predicate) => db.Comments.Where(predicate);

        public Comment ReadItemById(int id) => db.Comments.Find(id);

        public IEnumerable<Comment> ReadList() => db.Comments;

        public void Update(Comment item) => db.Entry(item).State = EntityState.Modified;
    }
}
