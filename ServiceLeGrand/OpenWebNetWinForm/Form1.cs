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

        private void gateway_MessageReceived(object sender, OpenWebNetDataEventArgs e) {
            Console.WriteLine(e.Data);
        }


        private void buttonTest_Click(object sender, EventArgs e)
        {
            /*
            OpenWebNetGateway.getInstance("172.16.0.209", 20000, OpenSocketType.Command).MessageReceived += new EventHandler<OpenWebNetDataEventArgs>(gateway_MessageReceived);
            Light light = new Light(0, "Light_Salon", false, 1, 50);
            light.OpenWebNetGateway = OpenWebNetGateway.getInstance("172.16.0.209", 20000, OpenSocketType.Command);
            light.OpenWebNetGateway.Connect();
            light.LightingLightOFF("12");
            light.LightingGetLightStatus("12");
            

            ServiceLegrand.ServiceLegrand o = new ServiceLegrand.ServiceLegrand();

            
            //Test AddUser
            User user = new User();
            user = user.add("test43", "test42", "mai42l@mail.mail", "password42");

            //Test AddHome
            Home home = new Home();
            home = home.add(null, "homeName", (float)42.3, (float)150.2);

            */
            //Création Home
            
            Home loicHome = new Home();
            loicHome.retrieveByUserId(1);

            int alor;
            alor = 2;

            /*
            Room cuisine = new Room(0, "Cuisine", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"), loicHome);

            cuisine.addEquipment(new Light(0, "Light1", false, 1, 50, cuisine));
            cuisine.addEquipment(new Light(0, "Light2", false, 2, 50, cuisine));
            cuisine.addEquipment(new Light(0, "Light3", false, 3, 50, cuisine));

            Room salleDeBain = new Room(0, "Salle de Bain", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"), loicHome);

            salleDeBain.addEquipment(new Light(0, "Light1", false, 1, 50, salleDeBain));
            salleDeBain.addEquipment(new Light(0, "Light2", false, 2, 50, salleDeBain));
            salleDeBain.addEquipment(new Light(0, "Light3", false, 3, 50, salleDeBain));

            Room salon = new Room(0, "Salon", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"), loicHome);

            salon.addEquipment(new Light(0, "Light1", false, 1, 50, salon));
            salon.addEquipment(new Light(0, "Light2", false, 2, 50, salon));
            salon.addEquipment(new Light(0, "Light3", false, 3, 50, salon));

            loicHome.addRoom(cuisine);
            loicHome.addRoom(salleDeBain);
            loicHome.addRoom(salon);
            */
            

            Console.WriteLine("STOP");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
