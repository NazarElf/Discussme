using System.ServiceModel;

namespace Discussme.BLL.ServiceInterfaces
{
    //Service for interaction with db objects that isn't user
    [ServiceContract]
    interface IForumDataService
    {
        [OperationContract]
        void AddSection(int id, string title, string description);
    }
}
