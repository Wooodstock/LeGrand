using ServiceLegrand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenWebNetDataContract.Model;
using OpenWebNetDataContract.Gateway;

namespace OpenWebNetWinForm
{
    public partial class Form1 : Form
    {
        private ServiceHost host;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            host.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(ServiceLegrand.ServiceLegrand));
            host.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {

            /*
            Light light = new Light(0, "Light_Salon", false, 1, 50);
            light.OpenWebNetGateway = new OpenWebNetGateway("172.16.0.209", 20000, OpenSocketType.Command);
            light.OpenWebNetGateway.Connect();
            light.LightingLightOFF("1");*/

            //Test AddUser
            /*User user = new User();
            user = user.add("test42", "test42", "mai42l@mail.mail", "password42");*/

            //Test AddHome
            Home home = new Home();
            home = home.add(null, "homeName", (float)42.3, (float)150.2);

            Console.WriteLine("STOP");
            //*/
            


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
