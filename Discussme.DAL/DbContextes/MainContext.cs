using System.Data.Entity;
using Discussme.DAL.Entities;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discussme.DAL.DbContextes
{
    public class MainContext : IdentityDbContext<IdentityForumUser>
    {

        public MainContext(string connectionString) : base(connectionString) { }
        public MainContext() : base("DbConnection") { }
        static MainContext() => Database.SetInitializer<MainContext>(new MainContextInitializer());

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> MyUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Section>().Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<Topic>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
    }

    class MainContextInitializer : DropCreateDatabaseAlways<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            Section sect0 = new Section { Title = "General discussion", Description = "" };
            Section sect1 = new Section { Title = "Music", Description = "Here you can discuss about music" };
            Section sect2 = new Section { Title = "Food", Description = "Recipies, advices, all about food" };
            Topic topic0 = new Topic {
                Title = "Rules",
                Description = "[1] Do not abuse anyone, you can be banned ... etc.",
                CreationTime = DateTime.Now,
                SectionId = 1
            };
            Topic topic1 = new Topic {
                Title = "What are you listen?",
                Description = "Here we share music",
                CreationTime = DateTime.Now,
                SectionId = 2
            };
            Topic topic2 = new Topic {
                Title = "The L**** ** *** ***nd",
                Description = "It was amazing music at that concerte... etc. ",
                CreationTime = DateTime.Now,
                SectionId = 2
            };
            Topic topic3 = new Topic {
                Title = "Recipies",
                Description = "Here we share recipies",
                CreationTime = DateTime.Now,
                SectionId = 3
            };
            Topic topic4 = new Topic {
                Title = "Advices",
                Description = "[some advice]",
                CreationTime = DateTime.Now,
                SectionId = 3
            };


            context.Sections.Add(sect0);
            context.Sections.Add(sect1);
            context.Sections.Add(sect2);

            context.Topics.Add(topic0);
            context.Topics.Add(topic1);
            context.Topics.Add(topic2);
            context.Topics.Add(topic3);
            context.Topics.Add(topic4);

            context.SaveChanges();
        }
    }
}
