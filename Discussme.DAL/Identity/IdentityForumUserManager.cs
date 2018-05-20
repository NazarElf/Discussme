using Discussme.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussme.DAL.Identity
{
    public class IdentityForumUserManager : UserManager<IdentityForumUser>
    {
        public IdentityForumUserManager(IUserStore<IdentityForumUser> store) : base(store)
        {
        }
    }
}
