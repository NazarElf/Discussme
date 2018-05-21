using System;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;
using Discussme.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

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
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentsRepository == null)
                    commentsRepository = new CommentsRepository(db);
                return commentsRepository;
            }
        }

        public IRepository<Section> Sections
        {
            get
            {
                if (sectionsRepository == null)
                    sectionsRepository = new SectionsRepository(db);
                return sectionsRepository;
            }
        }

        public IRepository<Topic> Topics
        {
            get
            {
                if (topicsRepository == null)
                    topicsRepository = new TopicsRepository(db);
                return topicsRepository;
            }
        }

        public IRepository<User> Users
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
