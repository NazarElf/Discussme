using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discussme.BLL.ServiceInterfaces;
using Discussme.BLL.DbObjects;
using AutoMapper;

namespace Discussme.BLL.ServiceClasses
{
    
    class ForumDataService : IForumDataService
    {
        Discussme.DAL.Interfaces.IUnitOfWork db;

        public ForumDataService()
        {
            db = new Discussme.DAL.DbClasses.UnitOfWork(@"source=(localdb)\MSSQLLocalDB;Initial Catalog=userstore.mdf;Integrated Security=True;");
        }

        public void AddSection(int id, string title, string description)
        {
            //SectionB section = new SectionB();
            //section.Id = id;
            //section.Title = title;
            //section.Description = description;
            //Mapper.Initialize(cfg => cfg.CreateMap<SectionB, Discussme.DAL.Entities.Section>());
            Discussme.DAL.Entities.Section sect = new DAL.Entities.Section();
            sect.Id = id;
            sect.Title = title;
            sect.Description = description;
            db.Comments.ReadList();
            db.Save();
        }
    }
}
