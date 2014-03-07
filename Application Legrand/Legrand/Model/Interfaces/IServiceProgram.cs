using Legrand.ServiceLegrand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legrand.Model.Interfaces {

    public interface IServiceProgram {

        void GetProgramList(Action<ObservableCollection<Program>> callback);
    }
}
