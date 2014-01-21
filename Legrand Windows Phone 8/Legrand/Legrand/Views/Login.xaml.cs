using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Notification;

namespace Legrand.View {
    public partial class Login : PhoneApplicationPage {
        public Login() {
            InitializeComponent();
        }

        private void Reset(object sender, System.EventArgs e) {

            login.Text = "";
            password.Password = "";
        }

        private void ButtonConnexion(object sender, System.Windows.Input.GestureEventArgs e) {

            ShellToast toast = new ShellToast();
            toast.Title = "Connexion à l'application : ";
            toast.Content = "Connexion réussie !";
            
            if (login.Text == "test" && password.Password == "test") {
                toast.Show();
                NavigationService.Navigate(new Uri("/View/Principale.xaml", UriKind.Relative));
            }
            else {

                erreur.Visibility = Visibility.Visible;
            }
        }
    }
}