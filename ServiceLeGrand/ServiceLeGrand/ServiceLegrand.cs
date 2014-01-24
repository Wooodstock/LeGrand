using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;

namespace ServiceLegrand
{
    public class ServiceLegrand : IServiceLegrand
    {
        public Home serviceHome(string order, Home home, Dictionary<object, object> dico) {
            throw new NotImplementedException();
        }

        public Equipment serviceEquipment(string order, Home home, Dictionary<object, object> dico) {
            throw new NotImplementedException();
        }
    }
}
