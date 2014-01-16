using GalaSoft.MvvmLight;
using MvvmLight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MvvmLight.ViewModel {

    public class VoirClientViewModel : ViewModelBase {

        private readonly IServiceClient serviceClient;

        private string prenom;

        public string Prenom {

            get { return prenom; }
            set { NotifyPropertyChanged(ref prenom, value); }
        }


        private int age;

        public int Age {

            get { return age; }
            set { NotifyPropertyChanged(ref age, value); }
        }

        private SolidColorBrush bonClient;

        public SolidColorBrush BonClient {

            get { return bonClient; }
            set { NotifyPropertyChanged(ref bonClient, value); }
        }

        private bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string nomPropriete = null) {
            if (object.Equals(variable, valeur)) return false;

            variable = valeur;
            RaisePropertyChanged(nomPropriete);
            return true;
        }

        public VoirClientViewModel(IServiceClient service) {

            serviceClient = service;

            Client client = serviceClient.Charger();
            Prenom = client.Prenom;
            Age = client.Age;
            if (client.EstBonClient)
                BonClient = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            else
                BonClient = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
        }
    }
}
