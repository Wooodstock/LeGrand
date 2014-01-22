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
    public interface IServiceHome
    {
        [OperationContract]
        Home addHome(List<Room> rooms, String name, float surface, float volume);

        [OperationContract]
        Boolean removeHome(Home home);

        [OperationContract]
        Home updateHome(Home home);
    }
}
