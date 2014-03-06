using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Legrand.Resources;
using Legrand.ViewModel;
using Legrand.ServiceLegrand;

namespace Legrand {
    public partial class MainPage : PhoneApplicationPage {

        public MainPage() {

            InitializeComponent();
        }

        private void AddProgramButton(object sender, System.Windows.Input.GestureEventArgs e) {

            NavigationService.Navigate(new Uri("/View/AddProgramPage.xaml", UriKind.Relative));
        }

        private void AccessProgram(object sender, System.Windows.Input.GestureEventArgs e) {

            Button b = (Button)sender;
            NavigationService.Navigate(new Uri("/View/AddProgramPage.xaml?program=" + b.Tag, UriKind.Relative));
        }
    }
}