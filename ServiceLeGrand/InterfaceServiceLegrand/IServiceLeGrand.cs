using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;

namespace ServiceLegrand
{
    public interface IServiceLegrand
    {

        Home serviceHome(string order, Home home, Dictionary<object, object> dico);

        Equipment serviceEquipment(string order, Home home, Dictionary<object, object> dico);

    }
}
