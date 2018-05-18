﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;

namespace Discussme.DAL.DbClasses
{
    class TopicsRepository : IRepository<Topic>
    {
        MainContext db;

        public TopicsRepository(MainContext db) => this.db = db;

        public void Create(Topic item) => db.Topics.Add(item);

        public void DeleteById(int id) => db.Topics.Remove(ReadItemById(id));

        public IEnumerable<Topic> FindAll(Func<Topic, bool> predicate) => db.Topics.Where(predicate);

        public Topic ReadItemById(int id) => db.Topics.Find(id);

        public IEnumerable<Topic> ReadList() => db.Topics;

        public void Update(Topic item) => db.Entry(item).State = EntityState.Modified;
    }
}
