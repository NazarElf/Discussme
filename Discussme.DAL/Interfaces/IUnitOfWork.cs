using System;
using Discussme.DAL.Entities;
using Discussme.DAL.Identity;
using System.Threading.Tasks;

namespace Discussme.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Comment> Comments { get; }
        IRepository<Section> Sections { get; }
        IRepository<Topic> Topics { get; }
        IRepository<User> Users { get; }

        IClientManager ClientManager { get; }
        ForumRoleManager RoleManager { get; }
        IdentityForumUserManager UserManager { get; }

        Task SaveAsync();
        void Save();
    }
}
