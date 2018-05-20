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
            //Mapper.Initialize(cfg => cfg.CreateMap<SectionB, Section>());
        }

        public void AddSection(int id, string title, string description)
        {
            // DON'T FORGET TO FIX IT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //db.Sections.DeleteById(id);
            //db.Save();
            //db.Sections.Create(null);
        }

        public void AddTopic(TopicB topic)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TopicB, Topic>());
            Topic t = Mapper.Map<TopicB, Topic>(topic);
            //t.SectionId = 1;
            db.Topics.Create(t);
            db.Sections.ReadItemById(topic.SectionId).Topics.Add(t);
            db.Save();
            Mapper.Reset();
        }

        public SectionB GetSectionById(int id)
        {
            Mapper.Initialize(c => c.CreateMap<Section, SectionB>());
            SectionB res = Mapper.Map<SectionB>(db.Sections.ReadItemById(id));
            Mapper.Reset();
            return res;
        }

        public IEnumerable<Section> GetSections()
        {
            return db.Sections.ReadList();
        }

        public IEnumerable<TopicB> GetAllTopics()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Topic, TopicB>());
            foreach (var item in db.Topics.ReadList())
            {
                yield return Mapper.Map<TopicB>(item);
            }
            Mapper.Reset();
        }

        public IEnumerable<TopicB> GetTopicsInSection(int sectionId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Topic, TopicB>());
            var section = db.Sections.ReadItemById(sectionId);
            foreach (var item in section.Topics)
            {
                yield return Mapper.Map<TopicB>(item);
            }
            Mapper.Reset();
        }
    }
}
