using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using System.ServiceModel;
using InterfaceServiceLegrand;

namespace ServiceLeGrand
{
    public class ServiceRoom : IServiceRoom
    {
        public Room addRoom(String name, float surface, List<Equipment> equipments, Consumption consumption)
        {
            throw new NotImplementedException();
        }

        public Boolean removeRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Room updateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Equipment addEquipment(String name, Boolean state, float temperature, int intensity)
        {
            throw new NotImplementedException();
        }

        public Boolean removeEquipment(Equipment equipement)
        {
            throw new NotImplementedException();
        }

        public Equipment updateEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}
