using System.ServiceModel;
using System.Collections.Generic;
using Discussme.BLL.DbObjects;
using System;

namespace Discussme.BLL.ServiceInterfaces
{
    //Service for interaction with db objects that isn't user
    [ServiceContract]
    interface IForumService
    {
        #region Methods with users

        [OperationContract]
        bool RegisterUser(UserB registerUser);

        [OperationContract]
        bool Login(LoginData data);

        [OperationContract]
        bool ChangeData(UserB toChange);

        #endregion

        #region Create methods

        [OperationContract]
        void AddSection(SectionB section);

        [OperationContract]
        void AddTopic(TopicB topic);

        [OperationContract]
        void AddComment(CommentB comment);

        #endregion

        #region Read methods

        [OperationContract]
        IEnumerable<SectionB> GetAllSections();

        [OperationContract]
        IEnumerable<TopicB> GetTopicsInSection(int sectionId);

        [OperationContract]
        IEnumerable<CommentB> GetCommentsInTopic(int topicId);

        [OperationContract]
        IEnumerable<TopicB> GetAllTopicsByPredicate(Func<TopicB, bool> predicate);

        [OperationContract]
        IEnumerable<CommentB> GetAllComentsByPredicate(Func<CommentB, bool> predicate);

        #endregion

        #region Update methods

        [OperationContract]
        void UpdateSection(SectionB section);

        [OperationContract]
        void UpdateComment(CommentB comment);

        [OperationContract]
        void UpdateTopic(TopicB topic);

        #endregion

        #region Delete methods

        [OperationContract]
        void RemoveSection(SectionB section);

        [OperationContract]
        void RemoveTopic(TopicB topic);

        [OperationContract]
        void RemoveComment(CommentB comment);

        #endregion
    }
}
