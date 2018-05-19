using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discussme.BLL.ServiceInterfaces;
using Discussme.BLL.DbObjects;
using AutoMapper;
using Discussme.DAL.Entities;

namespace Discussme.BLL.ServiceClasses
{
    
    class ForumDataService : IForumDataService
    {
        Discussme.DAL.Interfaces.IUnitOfWork db;

        public ForumDataService()
        {
            db = new Discussme.DAL.DbClasses.UnitOfWork();
        }

        public void AddSection(int id, string title, string description)
        {
            db.Sections.DeleteById(id);
            db.Save();
            //db.Sections.Create(null);
        }

        public IEnumerable<Section> GetSections()
        {
            return db.Sections.ReadList();
        }
    }
}
