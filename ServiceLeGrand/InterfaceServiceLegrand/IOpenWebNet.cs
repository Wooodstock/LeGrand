using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace InterfaceServiceLegrand
{
    [ServiceContract]
    public interface IOpenWebNet : IServiceHome, IServiceLeGrand, IServiceProgram, IServiceRoom, IServiceUser
    {
    }
}
