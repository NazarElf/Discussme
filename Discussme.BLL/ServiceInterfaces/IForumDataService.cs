using System.ServiceModel;
using System.Collections.Generic;
using Discussme.BLL.DbObjects;

namespace Discussme.BLL.ServiceInterfaces
{
    //Service for interaction with db objects that isn't user
    [ServiceContract]
    interface IForumDataService
    {
        [OperationContract]
        void AddSection(int id, string title, string description);

        [OperationContract]
        IEnumerable<Discussme.DAL.Entities.Section> GetSections();

        [OperationContract]
        void AddTopic(TopicB topic);

        [OperationContract]
        IEnumerable<TopicB> GetTopicsInSection(int sectionId);

        [OperationContract]
        IEnumerable<TopicB> GetAllTopics();

        [OperationContract]
        SectionB GetSectionById(int id);
    }
}
