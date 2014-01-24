using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLegrand.WallAccess
{
    public partial class OpenWebNetGateway
    {
        public void HeatingSetZoneAuto(string where)
        {
            SendCommand(WHO.Heating, "311", string.Format("#{0}", where));
        }

        public void HeatingSetZoneOFF(string where)
        {
            SendCommand(WHO.Heating, "303", string.Format("#{0}", where));
        }
    }
}
