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
        private List<User> Users;
        private List<Room> rooms;
        private List<Equipment> equips;
        private Room updatedRoom;
        private User updatedUser;
        private Equipment updatedequipment;
        private Home maison;
        private Timer timer;

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

            this.maison = new Home();
            maison.retrieveByUserId(1);

            loadcombobox();
        }

        private void launchTick() {
            /* Adds the event and the event handler for the method that will 
   process the timer event to the timer. */
            timer.Tick += new EventHandler(Tick);

            // Sets the timer interval to 5 seconds.
            timer.Interval = 60000;
            timer.Start();
        
        }

        private void Tick(Object myObject, EventArgs myEventArgs)
        {
            checkPrograms();
        }

        private void checkPrograms() {

            // Notre liste de programmes
            List<OpenWebNetDataContract.Model.Program> programs = new List<OpenWebNetDataContract.Model.Program>();

            // TODO : retrive all programms

            // Notre date courante
            DateTime currentDateTime = DateTime.Now;

            foreach (OpenWebNetDataContract.Model.Program program in programs) { 
                // Si le programme a une liste de jour programmés
                if(program.WorkingDays.Count > 0){
                    foreach(OpenWebNetDataContract.Model.Day day in program.WorkingDays){
                        if (currentDateTime.DayOfWeek == day.dayInWeek()
                            && currentDateTime.Hour == program.StartHour.Hour
                            && currentDateTime.Hour == program.StartHour.Hour)
                        {
                            program.run();
                        }
                    
                    }
                } else {
                    if (currentDateTime.Hour == program.StartHour.Hour
                        && currentDateTime.Hour == program.StartHour.Hour)
                    {
                        program.run();
                    }
                }
            
            }
        
        }

        private void loadcombobox()
        {
            cbRooms.Items.Clear();
            cbRooms.Text = "";
            cbUsers.Items.Clear();
            cbUsers.Text = "";

            this.maison.retrieveByUserId(1);
            this.rooms = maison.Rooms;

            Users = User.retrieveAllUser();

            foreach (User user in Users)
            {
                cbUsers.Items.Add(user.Name);
            }

            foreach (Room room in rooms)
            {
                cbRooms.Items.Add(room.Name);
            }


        }

        private void loadEquip(Room updatedRoom)
        {
            cbEquip.Items.Clear();
            cbEquip.Text = "";

            foreach (Equipment equipement in updatedRoom.Equipments)
            {
                cbEquip.Items.Add(equipement.Name);
            }
            
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
            light.LightingLightON("12");
            light.LightingGetLightStatus("12");
            
            ServiceLegrand.ServiceLegrand o = new ServiceLegrand.ServiceLegrand();

            //Test AddUser
            User user = new User();
            user = user.add("test43", "test42", "mai42l@mail.mail", "password42");


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

        private void btnaddUser_Click(object sender, EventArgs e)
        {
            User Client = new User();
            Client = Client.add(tbaddPrenom.Text, tbaddNom.Text, tbaddEmail.Text, tbaddMdp.Text);

            cbUsers.Items.Clear();
            tbaddPrenom.Text = "";
            tbaddNom.Text = "";
            tbaddEmail.Text = "";
            tbaddMdp.Text = "";
            loadcombobox();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnupdateUser_Click(object sender, EventArgs e)
        {
            updatedUser.Name = tbupdatePrenom.Text;
            updatedUser.Surname = tbupdateNom.Text;
            updatedUser.Mail = tbupdateEmail.Text;
            updatedUser.Password = tbupdateMdp.Text;
            updatedUser.update();
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected text, you can also use SelectedIndex and SelectedValue
            int selectedIndex = cbUsers.SelectedIndex;

            updatedUser = Users.ElementAt(selectedIndex);

            tbupdatePrenom.Text = updatedUser.Name;
            tbupdateNom.Text = updatedUser.Surname;
            tbupdateEmail.Text = updatedUser.Mail;
            tbupdateMdp.Text = updatedUser.Password;
        }

        private void btndelUser_Click(object sender, EventArgs e)
        {
            int selectedIndex = cbUsers.SelectedIndex;
            updatedUser = Users.ElementAt(selectedIndex);
            updatedUser.remove();
            tbupdatePrenom.Text = "";
            tbupdateNom.Text = "";
            tbupdateEmail.Text = "";
            tbupdateMdp.Text = "";
            loadcombobox();

        }

        private void btnaddPiece_Click(object sender, EventArgs e)
        {
            Room newRoom = new Room(0, tbaddPiece.Text, (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
            newRoom = newRoom.add(this.maison.Id);

            cbRooms.Items.Clear();
            tbaddPiece.Text = "";
            loadcombobox();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbRooms.SelectedIndex;
            updatedRoom = rooms.ElementAt(selectedIndex);

            this.equips = updatedRoom.Equipments;

            loadEquip(updatedRoom);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            updatedRoom.Name = cbRooms.Text;
            updatedRoom.update();
            loadcombobox();
        }

        private void deleteRoom_Click(object sender, EventArgs e)
        {
            int selectedIndex = cbRooms.SelectedIndex;
            updatedRoom = rooms.ElementAt(selectedIndex);
            updatedRoom.remove();
            loadcombobox();
        }

        private void cbEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbEquip.SelectedIndex;
            this.updatedequipment = this.equips.ElementAt(selectedIndex);
            tbupdateidEquip.Text = this.updatedequipment.Number.ToString();
        }

        private void updateEquip_Click(object sender, EventArgs e)
        {

        }
    }
}
