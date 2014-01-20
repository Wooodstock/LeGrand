using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.Model
{
    class User
    {
        public User()
        {

        }

        public User(int id, String name, String surname, String mail, String password) {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.mail = mail;
            this.password = password;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String surname;         

        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private String mail;

        public String Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
