using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLegrand.WallAccess
{
    public partial class OpenWebNetGateway
    {
        /// <summary>
        /// Open shutter
        /// </summary>
        /// <param name="where">Specify the shutter to open</param>
        public void AutomationUp(string where)
        {
            SendCommand(WHO.Automation, "1", where);
        }

        /// <summary>
        /// Abbassa il punto di Automazione
        /// </summary>
        /// <param name="where">Specify the shutter to open</param>
        public void AutomationDown(string where)
        {
            SendCommand(WHO.Automation, "2", where);
        }

        /// <summary>
        /// Ferma il punto di Automazione
        /// </summary>
        /// <param name="where">Specifica il punto automazione da fermare</param>
        public void AutomationStop(string where)
        {
            SendCommand(WHO.Automation, "0", where);
        }

        /// <summary>
        /// Richiede lo stato del punto automazione
        /// </summary>
        /// <param name="where">Specifica il punto automazione</param>
        public void AutomationGetStatus(string where)
        {
            GetStateCommand(WHO.Automation, where);
        }
    }
}
