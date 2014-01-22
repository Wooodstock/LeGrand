using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using InterfaceServiceLegrand;
using System.Data;


namespace ServiceLeGrand
{
    public class ServiceUser : IServiceUser
    {
        public User addUser(String name, String surname, String mail, String password)
        {
            CAD.SQLite db;

            try
            {
                //Ajout de l'user en base
                db = new CAD.SQLite();
                int result;
                String query = "INSERT INTO User (Name, Surname, Mail, Password) VALUES ('"+ name +"', '"+ surname +"', '"+ mail +"', '"+ password +"');";
                result = db.ExecuteNonQuery(query);

                //Si pas derreur Creation de l'objet user a envoyer
                if(result > 0)
                {

                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        public Boolean removeUser(User user)
        {
            throw new NotImplementedException();
        }

        public User updateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Boolean connectUser(String mail, String password)
        {
            CAD.SQLite db;
            String dbPassword;

            try
            {
                db = new CAD.SQLite();
                DataTable result;
                String query = "SELECT Password FROM User WHERE Mail = '" + mail + "'";
                result = db.GetDataTable(query);
                dbPassword = "password";

                // boucle resultat reauete
                foreach (DataRow r in result.Rows)
                {
                    dbPassword = r["Password"].ToString();
                }

                if (password.Equals(dbPassword))
                {
                    Console.WriteLine("User " + mail + " connected");
                    //Connexionn SUCCES
                    return true;
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }
            return false;
        }

        public Boolean logout()
        {
            throw new NotImplementedException();
        }
    }
}
