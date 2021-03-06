﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.WallAccess
{
    public partial class OpenWebNetGateway
    {
        public void AlarmGetZoneStatus(int n)
        {
            if (n < 1 || n > 8)
                throw new ArgumentOutOfRangeException("N value wrong");

            GetStateCommand(WHO.Alarm, string.Format("#{0}", n.ToString()));
        }

        public void AlarmGetCentralUnitStatus()
        {
            GetStateCommand(WHO.Alarm, "");
        }

        public void AlarmGetAuxiliaresStatus()
        {
            throw new NotImplementedException();

            //GetStateCommand(9, "");
        }
    }
}
