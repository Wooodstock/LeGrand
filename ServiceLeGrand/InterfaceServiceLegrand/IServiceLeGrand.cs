using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using System.ServiceModel;

namespace InterfaceServiceLegrand
{
    [ServiceContract]
    public interface IServiceLegrand
    {
        [OperationContract]
        Home serviceHome(string order, Home home, Dictionary<object, object> dico);

        [OperationContract]
        Equipment serviceEquipment(string order, Home home, Dictionary<object, object> dico);

    }
}
