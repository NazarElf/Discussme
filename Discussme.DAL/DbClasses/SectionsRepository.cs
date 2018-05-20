using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;

namespace Discussme.DAL.DbClasses
{
    public class SectionsRepository : IRepository<Section>
    {
        DbContextes.MainContext db;

        public SectionsRepository(DbContextes.MainContext db) => this.db = db;

        public void Create(Section item) => db.Sections.Add(item);

        public void Delete(Section item) => db.Sections.Remove(item);

        public void DeleteById(int id) => db.Sections.Remove(ReadItemById(id));

        public IEnumerable<Section> FindAll(Func<Section, bool> predicate) => db.Sections.Where(predicate);

        public Section ReadItemById(int id) => db.Sections.Find(id);

        public IEnumerable<Section> ReadList() => db.Sections;

        public void Update(Section item) => db.Entry(item).State = EntityState.Modified;
    }
}
