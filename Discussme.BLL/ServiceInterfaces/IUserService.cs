using System.ServiceModel;

namespace Discussme.BLL.ServiceInterfaces
{
    [ServiceContract]
    interface IUserService
    {
        [OperationContract]
        bool RegisterUser();

        [OperationContract]
        bool Login();


    }
}
