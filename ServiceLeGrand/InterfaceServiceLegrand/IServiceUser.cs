using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;

namespace InterfaceServiceLegrand
{
    [ServiceContract]
    public interface IServiceUser
    {
        [OperationContract]
        User addUser(String name, String surname, String mail, String password);

        [OperationContract]
        Boolean removeUser(User user);

        [OperationContract]
        User updateUser(User user);

        [OperationContract]
        Boolean connectUser(String login, String password);

        [OperationContract]
        Boolean logout();
    }
}
