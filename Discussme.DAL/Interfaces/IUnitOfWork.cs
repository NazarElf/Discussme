using System;
using Discussme.DAL.Entities;
using Discussme.DAL.Identity;
using System.Threading.Tasks;

namespace Discussme.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Comment, int> Comments { get; }
        IRepository<Section, int> Sections { get; }
        IRepository<Topic, int> Topics { get; }
        IRepository<User, string> Users { get; }

        IClientManager ClientManager { get; }
        ForumRoleManager RoleManager { get; }
        IdentityForumUserManager UserManager { get; }

        Task SaveAsync();
        void Save();
    }
}
