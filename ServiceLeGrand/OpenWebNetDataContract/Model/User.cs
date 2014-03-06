using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public class User
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

        [DataMember]
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        private String surname;         

        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        [DataMember]
        private String mail;

        public String Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        [DataMember]
        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public User add(String name, String surname, String mail, String password) {
            CAD.SQLite db;

            //TODO: Check if user deja en base

            try
            {
                //Ajout de l'user en base
                db = CAD.SQLite.getInstance();
                String InsertQuery = "INSERT INTO User (Name, Surname, Mail, Password) VALUES ('" + name + "', '" + surname + "', '" + mail + "', '" + password + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id de l'user (mail doit etre unique)
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM User WHERE Mail = '" + mail + "'";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }

                    //Creation de lobjet User
                    if (id != 0)
                    {
                        User user = new User(id, name, surname, mail, password);
                        Console.WriteLine("New User Created");
                        return user;
                    }
                    else
                    {
                        Console.WriteLine("Erreur creation User");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation User");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation User - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        public bool removeUser(User user)
        {
            CAD.SQLite db;

            try
            {
                db = CAD.SQLite.getInstance();
                int updatedRow = 0;
                String query = "DELETE FROM User WHERE Id = " + user.Id + ";";

                updatedRow = db.ExecuteNonQuery(query);
                if (updatedRow > 0)
                {
                    Console.WriteLine("User deleted");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: User was not deleted");
                    return false;
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }
        }

        public Boolean remove(User user)
        {
            throw new NotImplementedException();
        }

        public Boolean update()
        {
            CAD.SQLite db;
            try
            {
                db = CAD.SQLite.getInstance();
                int updatedRow = 0;
                String query = "UPDATE User SET Name='" + this.Name + "', Surname='" + this.Surname + "', Mail='" + this.Mail + "', Password='" + this.Password + "' WHERE Id=" + this.Id + ";";

                updatedRow = db.ExecuteNonQuery(query);

                if (updatedRow > 0)
                {
                    Console.WriteLine("user updated");
                    return true;
                }
                else
                {
                    Console.WriteLine("error: user not updated");
                    return false;
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }
        }

        public int connect()
        {
            //TODO: Return user & this.user = user;

            CAD.SQLite db;
            String dbPassword;

            try
            {
                db = CAD.SQLite.getInstance();
                DataTable result;
                String query = "SELECT Password FROM User WHERE Mail = '" + this.mail + "'";
                result = db.GetDataTable(query);
                dbPassword = "password";

                // boucle resultat reauete
                foreach (DataRow r in result.Rows)
                {
                    dbPassword = r["Password"].ToString();

                    if (this.password.Equals(dbPassword))
                    {
                        Console.WriteLine("User " + this.mail + " connected");
                        //Connexionn SUCCES, on retourne l'id de l'utilisateur
                        return (int)r["Id"];
                    }
                }


            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return -1;
            }
            return -1;
        }

        public static List<User> retrieveAllUser()
        {
            CAD.SQLite db;

            try
            {
                db = CAD.SQLite.getInstance();
                DataTable result;
                String query = "SELECT * FROM User";
                result = db.GetDataTable(query);
                List<User> users = new List<User>();
                // boucle resultat reauete
                foreach (DataRow r in result.Rows)
                {
                    User user = new User();
                    user.id = int.Parse(r["Id"].ToString());
                    user.name = r["Name"].ToString();
                    user.surname = r["Surname"].ToString();
                    user.mail = r["Mail"].ToString();
                    user.password = r["Password"].ToString();
                    users.Add(user);
                }
                return users;
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        public Boolean logout()
        {
            return true;
        }
    }
}
