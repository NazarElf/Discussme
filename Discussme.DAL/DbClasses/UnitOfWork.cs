using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discussme.DAL.Interfaces;
using Discussme.DAL.Entities;
using Discussme.DAL.DbContextes;

namespace Discussme.DAL.DbClasses
{
    class UnitOfWork : IUnitOfWork
    {
        private MainContext db;
        private CommentsRepository commentsRepository;
        private SectionsRepository sectionsRepository;
        private TopicsRepository topicsRepository;
        private UsersRepository usersRepository;

        public UnitOfWork(string connectionString) =>
            db = new MainContext(connectionString);

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

        private bool disposed = false;
        public virtual void Dispose()
        {
            if (!this.disposed)
            {
                db.Dispose();
                this.disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        public void Save() => db.SaveChanges();
    }
}
