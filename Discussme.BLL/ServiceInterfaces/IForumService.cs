using System.Collections.Generic;
using Discussme.BLL.DbObjects;
using System;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Discussme.BLL.ServiceInterfaces
{
    //Service for interaction with db objects
    public interface IForumService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserB user);
        Task<ClaimsIdentity> AuthenticateAsync(UserB user);
        Task SetInitDataAsync(UserB admin, List<string> roles);


        #region Create methods

 
        void AddSection(SectionB section);

 
        void AddTopic(TopicB topic);

 
        void AddComment(CommentB comment);

        #endregion

        #region Read methods

 
        IEnumerable<SectionB> GetAllSections();

 
        IEnumerable<TopicB> GetTopicsInSection(int sectionId);

 
        IEnumerable<CommentB> GetCommentsInTopic(int topicId);

 
        IEnumerable<TopicB> GetAllTopicsByPredicate(Func<TopicB, bool> predicate);

 
        IEnumerable<CommentB> GetAllComentsByPredicate(Func<CommentB, bool> predicate);

        #endregion

        #region Update methods

 
        void UpdateSection(SectionB section);

 
        void UpdateComment(CommentB comment);

 
        void UpdateTopic(TopicB topic);

        #endregion

        #region Delete methods

 
        void RemoveSection(SectionB section);

 
        void RemoveTopic(TopicB topic);

 
        void RemoveComment(CommentB comment);

        #endregion
    }
}
