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
    public class Shutter : Equipment
    {
        public Shutter(int id, String name, Boolean state, int number)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
        }

        /// <summary>
        /// Open shutter
        /// </summary>
        /// <param name="where">Specify the shutter to open</param>
        public void AutomationUp(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Automation, "1", where);
        }

        /// <summary>
        /// Abbassa il punto di Automazione
        /// </summary>
        /// <param name="where">Specify the shutter to open</param>
        public void AutomationDown(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Automation, "2", where);
        }

        /// <summary>
        /// Ferma il punto di Automazione
        /// </summary>
        /// <param name="where">Specifica il punto automazione da fermare</param>
        public void AutomationStop(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Automation, "0", where);
        }

        /// <summary>
        /// Richiede lo stato del punto automazione
        /// </summary>
        /// <param name="where">Specifica il punto automazione</param>
        public void AutomationGetStatus(string where)
        {
            OpenWebNetGateway.GetStateCommand(WHO.Automation, where);
        }
    }
}
