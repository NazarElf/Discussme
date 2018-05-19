using System.Data.Entity;
using Discussme.DAL.Entities;
using System;

namespace Discussme.DAL.DbContextes
{
    public class MainContext : DbContext
    {

        public MainContext(string connectionString) : base(connectionString) { }
        public MainContext() : base("DbConnection") { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Section section = new Section { Id = 0, Description = null, Title = "Main" };
            //Sections.Add(section);
            //Topic topic = new Topic { Id = 0,
            //    CreationTime = DateTime.Now,
            //    Creator = null,
            //    CreatorId = null,
            //    Description = "Info about forum",
            //    Title = "Main Topic",
            //    ParentSection = section,
            //    SectionId = section.Id };
            //Topics.Add(topic);
        }
    }
}
