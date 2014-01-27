using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Gateway;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public class Radiator : Equipment
    {
        public Radiator(int id, String name, Boolean state, int number, float temperature)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
            this.temperature = temperature;
        }

        [DataMember]
        private float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public void HeatingSetZoneAuto(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Heating, "311", string.Format("#{0}", where));
        }

        public void HeatingSetZoneOFF(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Heating, "303", string.Format("#{0}", where));
        }
    }
}
