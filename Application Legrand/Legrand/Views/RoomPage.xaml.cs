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
    public partial class RoomPage : PhoneApplicationPage {
        public RoomPage() {

            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) { 
            
            base.OnNavigatedTo(e); 
            string room;
            string selectedRoom;

            if(NavigationContext.QueryString.TryGetValue("room", out room)) {

                selectedRoom = room;
                title.Text = selectedRoom;
            }

            
        }
    }
}