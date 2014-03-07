using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Gateway;
using System.Data;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public class Alarm : Equipment
    {
        public Alarm(int id, String name, Boolean state, int number)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
        }

        public void AlarmGetZoneStatus(int n)
        {
            if (n < 1 || n > 8)
                throw new ArgumentOutOfRangeException("N value wrong");

            OpenWebNetGateway.GetStateCommand(WHO.Alarm, string.Format("#{0}", n.ToString()));
        }

        public void AlarmGetCentralUnitStatus()
        {
            OpenWebNetGateway.GetStateCommand(WHO.Alarm, "");
        }

        public void AlarmGetAuxiliaresStatus()
        {
            throw new NotImplementedException();

            //GetStateCommand(9, "");
        }

        override public void retrieveById(int id)
        {
            throw new NotImplementedException();
        }

        override public Boolean update()
        {
            throw new NotImplementedException();
        }
    }
}
