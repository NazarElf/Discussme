using System;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;
using Discussme.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Discussme.DAL.DbClasses
{
    public class UnitOfWork : IUnitOfWork
    {
        private MainContext db;
        private CommentsRepository commentsRepository;
        private SectionsRepository sectionsRepository;
        private TopicsRepository topicsRepository;
        private UsersRepository usersRepository;

        private ForumRoleManager roleManager;
        private IdentityForumUserManager userManager;
        private IClientManager clientManager;


        public UnitOfWork(string connectionString)
        {
            db = new MainContext(connectionString);
            userManager = new IdentityForumUserManager(new UserStore<IdentityForumUser>(db));
            roleManager = new ForumRoleManager(new RoleStore<ForumRole>(db));
            clientManager = new ClientManager(db);
        }

        public UnitOfWork()
        {
            db = new MainContext();
            userManager = new IdentityForumUserManager(new UserStore<IdentityForumUser>(db));
            roleManager = new ForumRoleManager(new RoleStore<ForumRole>(db));
            clientManager = new ClientManager(db);
            var roles = new string[]{ "user", "admin" };
            foreach (string item in roles)
            {
                var role = RoleManager.FindByNameAsync(item).Result;
                if (role == null)
                {
                    role = new ForumRole { Name = item };
                    RoleManager.CreateAsync(role);
                }
            }
            IdentityForumUser user = UserManager.FindByEmailAsync("nnn43@ukr.net").Result;
            if (user == null)
            {
                User admin = new User()
                {
                    LastSeenTime = DateTime.Now,
                    RegistrationTime = DateTime.Now,
                    Nickname = "Rover_Go",
                    Password = "MyMyMyMyPassword",
                    UserPrivacy = Enums.Privacy.Private,
                };
                user = new IdentityForumUser { Email = "nnn43@ukr.net", UserName = admin.Nickname };
                var res = UserManager.CreateAsync(user, admin.Password).Result;
                UserManager.AddToRole(user.Id, "admin");
                User profile = admin;
                profile.Id = user.Id;
                ClientManager.Create(profile);
                //return new OperationDetails(true, "Registration complited", "");
            }
            else
            {
                //return new OperationDetails(false, "User with that email is already exist", "Email");
            }
        }

        public IRepository<Comment, int> Comments
        {
            get
            {
                if (commentsRepository == null)
                    commentsRepository = new CommentsRepository(db);
                return commentsRepository;
            }
        }

        public IRepository<Section, int> Sections
        {
            get
            {
                if (sectionsRepository == null)
                    sectionsRepository = new SectionsRepository(db);
                return sectionsRepository;
            }
        }

        public IRepository<Topic, int> Topics
        {
            get
            {
                if (topicsRepository == null)
                    topicsRepository = new TopicsRepository(db);
                return topicsRepository;
            }
        }

        public IRepository<User, string> Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new UsersRepository(db);
                return usersRepository;
            }
        }

        public IdentityForumUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ForumRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Save() => db.SaveChanges();
    }
}
