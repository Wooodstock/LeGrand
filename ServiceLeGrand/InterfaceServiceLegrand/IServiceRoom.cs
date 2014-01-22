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
    public interface IServiceRoom
    {
        [OperationContract]
        Room addRoom(String name, float surface, List<Equipment> equipments, Consumption consumption);

        [OperationContract]
        Boolean removeRoom(Room room);

        [OperationContract]
        Room updateRoom(Room room);

        [OperationContract]
        Equipment addEquipment(String name, Boolean state, float temperature, int intensity);

        [OperationContract]
        Boolean removeEquipment(Equipment equipment);

        [OperationContract]
        Equipment updateEquipment(Equipment equipment);
    }
}
