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
    public partial class AddProgramPage : PhoneApplicationPage {
        public AddProgramPage() {
            InitializeComponent();
        }

         protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {

            base.OnNavigatedTo(e);
            string program;

            if (NavigationContext.QueryString.TryGetValue("program", out program)) {

                title.Text = program;
            }
         }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e) {
            if (MessageBox.Show("Vous n'avez pas sauvegardé votre programme, voulez-vous vraiment quitter cette page ?", "Attention", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel) {
                e.Cancel = true;
            }
            base.OnBackKeyPress(e);
        }

        private void SaveProgramButton(object sender, RoutedEventArgs e) {

        }

        private void Reset(object sender, RoutedEventArgs e) {

        }
    }
}