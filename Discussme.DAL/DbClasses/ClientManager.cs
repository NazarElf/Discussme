using Discussme.DAL.DbContextes;
using Discussme.DAL.Entities;
using Discussme.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussme.DAL.DbClasses
{
    public class ClientManager : IClientManager
    {
        public MainContext db { get; set; }
        public ClientManager(MainContext context) => db = context;

        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
