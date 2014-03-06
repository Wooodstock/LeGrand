using GalaSoft.MvvmLight.Messaging;
using Legrand.ServiceLegrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Legrand.ViewModel {

    public class ProgramViewModel : BaseViewModel {

        private Program program;
        public Program Program {

            get { return program; }
            set { NotifyPropertyChanged(ref program, value); }
        }

        public ProgramViewModel() {

            Messenger.Default.Register<Program>(this, (program) => {
                Deployment.Current.Dispatcher.BeginInvoke(() => {
                    this.Program = program;
                });
                Messenger.Default.Send<Uri>(new Uri("/View/AddProgramPage.xaml", UriKind.Relative));
            });
        }
    }
}
