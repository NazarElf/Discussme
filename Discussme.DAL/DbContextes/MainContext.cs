using System.Data.Entity;
using Discussme.DAL.Entities;

namespace Discussme.DAL.DbContextes
{
    public class MainContext : DbContext
    {

        public MainContext(string connectionString) : base(connectionString) { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
