using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Legrand.ServiceLegrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Legrand.ViewModel {

    public class LoginViewModel : BaseViewModel {

        public ICommand loginUser { get; set; }
        
        private User user;
        public User User {

            get { return user; }
            set { NotifyPropertyChanged(ref user, value); }
        }

        public LoginViewModel() {

            this.loginUser = new RelayCommand<User>(LoginUser);

            Messenger.Default.Register<User>(this, (user) => {
                Deployment.Current.Dispatcher.BeginInvoke(() => {
                    this.User = user;
                });
                Messenger.Default.Send<Uri>(new Uri("/View/MainPage.xaml", UriKind.Relative));
            });
        }

        private async void LoginUser(User user) {

            await base.RunAsyncTask(() => {
                Messenger.Default.Send<User>(user);
            });
        }
    }

    
}
