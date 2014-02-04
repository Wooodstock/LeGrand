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
using Legrand.ViewModels;
using Legrand.Views;
using Legrand.ServiceLegrand;

namespace Legrand {
    public partial class MainPage : PhoneApplicationPage {

        public MainPage() {
            InitializeComponent();
            Loaded += new RoutedEventHandler(ListLoaded);

            ServiceLegrandClient client = new ServiceLegrandClient("BasicHttpBinding_IServiceLegrand");

            client.serviceHomeCompleted += new EventHandler<serviceHomeCompletedEventArgs>(callBackServiceHome);

            try {
                client.serviceHomeAsync("", new Home(), null, null);
            }
            catch (Exception e) {
                coucou.Text = e.Message;
            }
        }

        public void callBackServiceHome(object sender, serviceHomeCompletedEventArgs e) {

            Home home = e.Result;
            ListRooms.Items.Clear();
            ListRooms.ItemsSource = home.rooms;
        }

        List<Program> programs = new List<Program>();
        string[] title = { "Nouveau programme", "Test", "Test2" };

        private void ListLoaded(object sender, RoutedEventArgs e) {
            
            foreach (String s in title) {

                programs.Add(new Program(s));
            }
            Programs.ItemsSource = programs;
        }

        private void AccessRoom(object sender, System.Windows.Input.GestureEventArgs e) {
            
            NavigationService.Navigate(new Uri("/Views/RoomPage.xaml?room=" + ListRooms.SelectedItem, UriKind.Relative));
        }

        private void AddProgramButton(object sender, System.Windows.Input.GestureEventArgs e) {

            NavigationService.Navigate(new Uri("/Views/AddProgramPage.xaml", UriKind.Relative));
        }

        private void AccessProgram(object sender, System.Windows.Input.GestureEventArgs e) {

            //NavigationService.Navigate(new Uri("/Views/AddProgram.xaml?" + ListItem.Text, UriKind.Relative));
        }
    }
}