using ServiceLeGrand;
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
            host = new ServiceHost(typeof(ServiceLeGrand.OpenWebNet));
            host.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            /*Test AddUser
            OpenWebNet o = new OpenWebNet();
            OpenWebNetDataContract.Model.User user = new OpenWebNetDataContract.Model.User();
            user = o.addUser("test", "test", "mail@mail.mail", "password");
            Console.WriteLine("STOP");
            //*/


        }
    }
}
