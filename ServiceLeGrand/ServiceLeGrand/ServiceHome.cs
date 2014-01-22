using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using InterfaceServiceLegrand;

namespace ServiceLeGrand
{
    public class ServiceHome : IServiceHome
    {
        public Home addHome(List<Room> rooms, String name, float surface, float volume)
        { 
            throw new NotImplementedException();
        }

        public Boolean removeHome(Home home)
        { 
            throw new NotImplementedException();
        }

        public Home updateHome(Home home)
        {
            throw new NotImplementedException();
        }
    }
}
