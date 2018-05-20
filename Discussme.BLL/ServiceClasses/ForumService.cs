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

    class ForumService : IForumService
    {
        Discussme.DAL.Interfaces.IUnitOfWork db;

        public ForumService()
        {
            db = new Discussme.DAL.DbClasses.UnitOfWork();
        }

        #region User

        public bool RegisterUser(UserB registerUser)
        {
            Mapper.Initialize(c => c.CreateMap<UserB, User>());
            //Need to check data
            db.Users.Create(Mapper.Map<User>(registerUser));
            return true;
        }

        public bool Login(LoginData data)
        {
            //Need to check password;
            throw new NotImplementedException();
        }

        public bool ChangeData(UserB toChange)
        {
            Mapper.Initialize(c => c.CreateMap<UserB, User>());
            //Need to check permission
            db.Users.Update(Mapper.Map<User>(toChange));
            return true;
        }

        #endregion

        #region Create

        public void AddTopic(TopicB topic)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TopicB, Topic>());
            //TODO: Check permission
            Topic t = Mapper.Map<TopicB, Topic>(topic);
            db.Topics.Create(t);
            db.Save();
            Mapper.Reset();
        }

        public void AddSection(SectionB section)
        {
            //TODO: Check permission
            Mapper.Initialize(c => c.CreateMap<SectionB, Section>());
            db.Sections.Create(Mapper.Map<Section>(section));
            Mapper.Reset();
        }

        public void AddComment(CommentB comment)
        {
            //TODO: Check permission
            Mapper.Initialize(c => c.CreateMap<CommentB, Comment>());
            db.Comments.Create(Mapper.Map<Comment>(comment));
            Mapper.Reset();
        }

        #endregion

        #region Read

        public SectionB GetSectionById(int id)
        {
            Mapper.Initialize(c => c.CreateMap<Section, SectionB>());
            SectionB res = Mapper.Map<SectionB>(db.Sections.ReadItemById(id));
            Mapper.Reset();
            return res;
        }

        public IEnumerable<TopicB> GetAllTopics()
        {
            Mapper.Initialize(c => c.CreateMap<Topic, TopicB>());
            var comments = Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicB>>(db.Topics.ReadList());
            Mapper.Reset();
            return comments;
        }

        public IEnumerable<TopicB> GetTopicsInSection(int sectionId)
        {
            Mapper.Initialize(c => c.CreateMap<Topic, TopicB>());
            var topics = Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicB>>(db.Sections.ReadItemById(sectionId).Topics);
            Mapper.Reset();
            return topics;
        }

        public IEnumerable<SectionB> GetAllSections()
        {
            Mapper.Initialize(c => c.CreateMap<Section, SectionB>());
            var sections = Mapper.Map<IEnumerable<Section>, IEnumerable<SectionB>>(db.Sections.ReadList());
            Mapper.Reset();
            return sections;
        }

        public IEnumerable<CommentB> GetCommentsInTopic(int topicId)
        {
            Mapper.Initialize(c => c.CreateMap<Comment, CommentB>());
            var comments = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentB>>(db.Topics.ReadItemById(topicId).Comments);
            Mapper.Reset();
            return comments;
        }

        public IEnumerable<TopicB> GetAllTopicsByPredicate(Func<TopicB, bool> predicate)
        {
            Mapper.Initialize(c => c.CreateMap<TopicB, Topic>());
            var res = db.Topics.FindAll(Mapper.Map<Func<TopicB, bool>, Func<Topic, bool>>(predicate));
            Mapper.Reset();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Topic, TopicB>()).CreateMapper();
            return mapper.Map<IEnumerable<Topic>, List<TopicB>>(res);
        }

        public IEnumerable<CommentB> GetAllComentsByPredicate(Func<CommentB, bool> predicate)
        {
            Mapper.Initialize(c => c.CreateMap<CommentB, Comment>());
            var res = db.Comments.FindAll(Mapper.Map<Func<CommentB, bool>, Func<Comment, bool>>(predicate));
            Mapper.Reset();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, Comment>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentB>>(res);
        }

        #endregion

        #region Update

        public void UpdateSection(SectionB section)
        {
            //TODO: Check permission
            Mapper.Initialize(c => c.CreateMap<SectionB, Section>());
            db.Sections.Update(Mapper.Map<Section>(section));
        }

        public void UpdateComment(CommentB comment)
        {
            //TODO: Check permission
            Mapper.Initialize(c => c.CreateMap<CommentB, Comment>());
            db.Comments.Update(Mapper.Map<Comment>(comment));
        }

        public void UpdateTopic(TopicB topic)
        {
            //TODO: Check permission
            Mapper.Initialize(c => c.CreateMap<TopicB, Topic>());
            db.Topics.Update(Mapper.Map<Topic>(topic));
        }

        #endregion

        #region Delete

        public void RemoveSection(SectionB section)
        {
            //TODO: Check permission
            db.Sections.DeleteById(section.Id);
        }

        public void RemoveTopic(TopicB topic)
        {
            //TODO: Check permission
            db.Topics.DeleteById(topic.Id);
        }

        public void RemoveComment(CommentB comment)
        {
            //TODO: Check permission
            db.Comments.DeleteById(comment.Id);
        }

        #endregion
    }
}
