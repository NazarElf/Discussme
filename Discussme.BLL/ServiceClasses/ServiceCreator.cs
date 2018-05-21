using Discussme.BLL.ServiceInterfaces;
using Discussme.DAL.DbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussme.BLL.ServiceClasses
{
    class ServiceCreator : IServiceCreator
    {
        public IForumService CreateForumService(string connection)
        {
            return new ForumService(new UnitOfWork(connection));
        }

        public IForumService CreateForumService()
        {
            return new ForumService(new UnitOfWork());
        }
    }
}
