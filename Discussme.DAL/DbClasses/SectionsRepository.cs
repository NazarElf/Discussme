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
    public class SectionsRepository : IRepository<Section, int>
    {
        DbContextes.MainContext db;

        public SectionsRepository(DbContextes.MainContext db) => this.db = db;

        public void Create(Section item)
        {
            db.Sections.Add(item);
            db.SaveChanges();
        }

        public async Task CreateAsync(Section item)
        {
            await Task.Run(() => db.Sections.Add(item));
            await db.SaveChangesAsync();
        }

        public void Delete(Section item)
        {
            db.Sections.Remove(item);
            db.SaveChanges();
        }

        public async Task DeleteAsync(Section item)
        {
            await Task.Run(() => db.Sections.Remove(item));
            await db.SaveChangesAsync();
        }

        public void DeleteById(int id)
        {
            db.Sections.Remove(ReadItemById(id));
            db.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Task.Run(async () => db.Sections.Remove(await ReadItemByIdAsync(id)));
            await db.SaveChangesAsync();
        }

        public IEnumerable<Section> FindAll(Func<Section, bool> predicate) 
            => db.Sections.Where(predicate);

        public async Task<IEnumerable<Section>> FindAllAsync(Func<Section, bool> predicate)
            => await Task.Run<IEnumerable<Section>>(() => db.Sections.Where(predicate));

        public Section ReadItemById(int id) 
            => db.Sections.Find(id);

        public async Task<Section> ReadItemByIdAsync(int id)
            => await Task.Run<Section>(() => db.Sections.Find(id));

        public IEnumerable<Section> ReadList() 
            => db.Sections;

        public async Task<IEnumerable<Section>> ReadListAsync()
            => await Task.Run<IEnumerable<Section>>(() => db.Sections);

        public void Update(Section item) 
            => db.Entry(item).State = EntityState.Modified;

        public async Task UpdateAsync(Section item)
            => await Task.Run(() => db.Entry(item).State = EntityState.Modified);
    }
}
