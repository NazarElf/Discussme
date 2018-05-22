using System.Data.Entity;
using Discussme.DAL.Entities;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Discussme.DAL.Identity;

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
            //modelBuilder.Entity<User>().
            base.OnModelCreating(modelBuilder);
        }
    }

    class MainContextInitializer : DropCreateDatabaseAlways<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            base.Seed(context);

            var userManager = new IdentityForumUserManager(new UserStore<IdentityForumUser>(context));
            var roleManager = new ForumRoleManager(new RoleStore<ForumRole>(context));

            roleManager.Create(new ForumRole { Name = "admin" });
            roleManager.Create(new ForumRole { Name = "user" });

            var admin = new IdentityForumUser { Email = "nnn43@ukr.net", UserName = "Rover_Go" };
            var user0 = new IdentityForumUser { Email = "yfpfh43@gmail.com", UserName = "NazarElf" };
            var user1 = new IdentityForumUser { Email = "128532a@mhvr.net", UserName = "Haccker" };
            var user2 = new IdentityForumUser { Email = "io53.kpi@gmail.com", UserName = "IO53" };
            var user3 = new IdentityForumUser { Email = "z25@ukr.net", UserName = "zZ_KoNDoR_Zz" };

            var res0 = userManager.Create(admin, "somebodY5_5Someone");
            var res1 = userManager.Create(user0, "Somebody4_4someonE");
            var res2 = userManager.Create(user1, "rndPass_c-:<");
            var res3 = userManager.Create(user2, "groupPass");
            var res4 = userManager.Create(user3, "Here'S_My_Number");

            if (res0.Succeeded)
                userManager.AddToRole(admin.Id, "admin");
            if (res1.Succeeded)
                userManager.AddToRole(user0.Id, "user");
            if (res2.Succeeded)
                userManager.AddToRole(user1.Id, "user");
            if (res3.Succeeded)
                userManager.AddToRole(user2.Id, "user");
            if (res4.Succeeded)
                userManager.AddToRole(user3.Id, "user");

            User adm = new User { Id = admin.Id, LastSeenTime = DateTime.Now, RegistrationTime = DateTime.Now, UserPrivacy = Enums.Privacy.Private };
            User usr0 = new User { Id = user0.Id, LastSeenTime = DateTime.Now, RegistrationTime = DateTime.Now, UserPrivacy = Enums.Privacy.Public };
            User usr1 = new User { Id = user1.Id, LastSeenTime = DateTime.Now, RegistrationTime = DateTime.Now, UserPrivacy = Enums.Privacy.Public };
            User usr2 = new User { Id = user2.Id, LastSeenTime = DateTime.Now, RegistrationTime = DateTime.Now, UserPrivacy = Enums.Privacy.Public };
            User usr3 = new User { Id = user3.Id, LastSeenTime = DateTime.Now, RegistrationTime = DateTime.Now, UserPrivacy = Enums.Privacy.Public };


            context.SaveChanges();

            Section sect0 = new Section { Title = "General discussion", Description = "" };
            Section sect1 = new Section { Title = "Music", Description = "Here you can discuss about music" };
            Section sect2 = new Section { Title = "Food", Description = "Recipies, advices, all about food" };
            Topic topic0 = new Topic
            {
                Title = "Rules",
                Description = "[1] Do not abuse anyone, you can be banned ... etc.",
                CreationTime = DateTime.Now,
                SectionId = 1
            };
            Topic topic1 = new Topic
            {
                Title = "What are you listen?",
                Description = "Here we share music",
                CreationTime = DateTime.Now,
                SectionId = 2
            };
            Topic topic2 = new Topic
            {
                Title = "The L**** ** *** ***nd",
                Description = "It was amazing music at that concerte... etc. ",
                CreationTime = DateTime.Now,
                SectionId = 2
            };
            Topic topic3 = new Topic
            {
                Title = "Recipies",
                Description = "Here we share recipies",
                CreationTime = DateTime.Now,
                SectionId = 3
            };
            Topic topic4 = new Topic
            {
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
            //await forumservice.setinitdataasync(new userb
            //{
            //    email = "nnn43@ukr.net",
            //    nickname = "rover_go",
            //    password = "somebody4_4someone",
            //    firstname = "nazar",
            //    lastname = "yurchenko",
            //    userrole = "admin",
            //    userprivacy = "public",
            //}, new list<string> { "user", "admin" });
        }
    }
}