using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Legrand.Model.Interfaces;
using Legrand.Model.Navigation;
using Legrand.Model.Services;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Legrand.ViewModel {

    public class BaseViewModel : ViewModelBase {

        public ICommand TextChangedCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        protected IServiceHome serviceHome;
        protected IServiceProgram serviceProgram;

        protected CustomNavigationService NavigationService { get; set; }

        public BaseViewModel() {

            this.serviceHome = new ServiceHome();
            this.serviceProgram = new ServiceProgram();
            this.TextChangedCommand = new RelayCommand<TextBox>(TextChanged);
            this.PasswordChangedCommand = new RelayCommand<PasswordBox>(PasswordChanged);
            this.NavigationService = new CustomNavigationService();

            Messenger.Default.Register<Uri>(this, (uri) => Deployment.Current.Dispatcher.BeginInvoke(() => { this.NavigationService.NavigateTo(uri); }));
        }

        protected bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string nomPropriete = null) {
            if (object.Equals(variable, valeur)) return false;

            variable = valeur;
            RaisePropertyChanged(nomPropriete);
            return true;
        }

        private void TextChanged(TextBox textBox) {
            // Update the binding source
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }

        private void PasswordChanged(PasswordBox passwordBox) {
            // Update the binding source
            BindingExpression bindingExpr = passwordBox.GetBindingExpression(PasswordBox.PasswordProperty);
            bindingExpr.UpdateSource();
        }

        protected async Task RunAsyncTask(Action task) {
            try {
                await Task.Run(task);
            }
            catch (AggregateException e) {
                string error = "Désolé, une erreur s'est produite";
#if DEBUG
                error += "\n" + e.Message;
#endif
                MessageBox.Show(error);
            }
        }
    }
}
