using System.ServiceModel;
using System.Collections.Generic;

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
    }
}
