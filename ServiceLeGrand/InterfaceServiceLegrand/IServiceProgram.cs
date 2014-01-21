using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceServiceLegrand.Model;
using System.ServiceModel;

namespace InterfaceServiceLegrand
{
    [ServiceContract]
    public interface IServiceProgram
    {
        [OperationContract]
        Program addProgram(String name, DateTime startHour, List<Day> workingDays, List<Room> rooms);

        [OperationContract]
        Boolean removeProgram(Program program);

        [OperationContract]
        Program updateProgram(Program program);
    }
}
