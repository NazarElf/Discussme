using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discussme.DAL.Entities;

namespace Discussme.DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Comment> Comments { get; }
        IRepository<Section> Sections { get; }
        IRepository<Topic> Topics { get; }
        IRepository<User> Users { get; }

        void Save();
    }
}
