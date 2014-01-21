using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceServiceLegrand.Model;
using System.ServiceModel;
using InterfaceServiceLegrand;

namespace ServiceLeGrand
{
    public class ServiceProgram : IServiceProgram
    {
        public Program addProgram(String name, DateTime startHour, List<Day> workingDays, List<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public Boolean removeProgram(Program program)
        {
            throw new NotImplementedException();
        }

        public Program updateProgram(Program program)
        {
            throw new NotImplementedException();
        }
    }
}
