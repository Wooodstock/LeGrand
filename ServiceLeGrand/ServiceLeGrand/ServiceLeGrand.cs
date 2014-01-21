using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using InterfaceServiceLegrand;

namespace ServiceLeGrand
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ServiceLeGrand : IServiceLeGrand
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public bool Connection(String mail, String password)
        {
            CAD.SQLite db;
            String dbPassword;

            try
            {
                db = new CAD.SQLite();
                DataTable result;
                String query = "SELECT Password FROM User WHERE Mail = '"+ mail +"'";
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

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
