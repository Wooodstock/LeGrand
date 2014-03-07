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
        [ServiceKnownType(typeof(Light))]
        [ServiceKnownType(typeof(Alarm))]
        [ServiceKnownType(typeof(Shutter))]
        [ServiceKnownType(typeof(Radiator))]
        Home serviceHome(string order, Home home, Dictionary<object, object> dico);

        [OperationContract]
        Equipment serviceEquipment(string order, Equipment equipment, Dictionary<object, object> dico);

        [OperationContract]
        Program serviceProgram(string order, Program program, Dictionary<object, object> dico);

        [OperationContract]
        Dictionary<object, object> serviceUser(string order, User user, Dictionary<object, object> dico);
    }
}
