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
        /// Turn ON the specified light point
        /// </summary>
        /// <param name="where">Specify the light point to turn ON</param>
        public void LightingLightON(string where)
        {
            SendCommand(WHO.Lighting, "1", where);
        }

        /// <summary>
        /// Turn OFF the light point specified
        /// </summary>
        /// <param name="where">Specify the light point to turn ON</param>
        public void LightingLightOFF(string where)
        {
            SendCommand(WHO.Lighting, "0", where);
        }

        /// <summary>
        /// get the light point status
        /// </summary>
        /// <param name="dove">specify the light point</param>
        public void LightingGetLightStatus(string dove)
        {
            GetStateCommand(WHO.Lighting, dove);
        }
    }
}
