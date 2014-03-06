using Legrand.Model.Interfaces;
using Legrand.ServiceLegrand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legrand.Model.Services {

    public class ServiceProgram : BaseService, IServiceProgram {

        public ServiceProgram() 
            : base() {
        }

        public void GetProgramList(Action<ObservableCollection<Program>>callback) {

            serviceLegrand.serviceProgramCompleted += new EventHandler<serviceProgramCompletedEventArgs>((sender, e) => {
                //CHECK NULL
                callback(e.Result);
            });
            serviceLegrand.serviceProgramAsync("", new Program(), null, null);
        }
    }
}
