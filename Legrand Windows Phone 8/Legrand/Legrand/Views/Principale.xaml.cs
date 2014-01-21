using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace Legrand.View {
    public partial class Principale : PhoneApplicationPage {

        public Principale() {

            InitializeComponent();
            this.toggle.Checked += new EventHandler<RoutedEventArgs>(toggle_Checked);
            this.toggle.Unchecked += new EventHandler<RoutedEventArgs>(toggle_Unchecked);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

        }


        private void Panorama_Loaded(object sender, RoutedEventArgs e) {

        }


        void toggle_Unchecked(object sender, RoutedEventArgs e) {
            this.toggle.Content = "Off";
            Result.Text = "PAS OKAY";
        }

        /*public Boolean hasService =false;
        ChannelFactory<DllService.MsgInterface> myChannelFactory = null;
        DllService.MsgInterface myService;*/

        

        void toggle_Checked(object sender, RoutedEventArgs e) {
            this.toggle.Content = "On";
            this.toggle.SwitchForeground = new SolidColorBrush(Colors.Cyan);

            try {
                Result.Text = "OKAY";
                /*myChannelFactory = ChannelFactory<DllService.MsgInterface>("ConfigurationHttpMessage");
                myService = myChannelFactory.CreateChannel();
                this.hasService = true;*/

            } catch (Exception ex) {

                //myChannelFactory.Abort();
                Console.WriteLine("An eccor occured : "+ex.Message);
            }
        }
    }
}