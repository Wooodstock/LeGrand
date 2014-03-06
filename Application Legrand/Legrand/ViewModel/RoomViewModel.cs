using GalaSoft.MvvmLight.Messaging;
using Legrand.ServiceLegrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Legrand.ViewModel {

    public class RoomViewModel : BaseViewModel {

        private Room room;
        public Room Room {

            get { return room; }
            set { NotifyPropertyChanged(ref room, value); }
        }
        
        public RoomViewModel() {

            Messenger.Default.Register<Room>(this, (room) => {
                Deployment.Current.Dispatcher.BeginInvoke(() => {
                    this.Room = room;
                });
                Messenger.Default.Send<Uri>(new Uri("/View/RoomPage.xaml", UriKind.Relative));
            });
        }
    }
}
