using Legrand.Model.Interfaces;
using Legrand.ServiceLegrand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legrand.Model.Services {

    public class ServiceHome : BaseService, IServiceHome {

        public ServiceHome()
            : base() {
        }

        public void GetRoomList(Action<ObservableCollection<Room>>callback) {

            serviceLegrand.serviceHomeCompleted += new EventHandler<serviceHomeCompletedEventArgs>((sender, e) => {
                //CHECK NULL
                callback(e.Result.rooms);
            });
            serviceLegrand.serviceHomeAsync("", new Home(), null, null);
        }
    }
}
