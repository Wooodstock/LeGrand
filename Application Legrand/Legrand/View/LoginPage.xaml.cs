using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Legrand.Views {
    public partial class LoginPage : PhoneApplicationPage {
        public LoginPage() {

            InitializeComponent();
        }

        private void Reset(object sender, RoutedEventArgs e) {

            login.Text = "";
            password.Password = "";
        }

        private void ButtonConnection(object sender, System.Windows.Input.GestureEventArgs e) {

        }
    }
}