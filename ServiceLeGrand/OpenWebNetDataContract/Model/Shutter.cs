using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Gateway;
using System.Data;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public class Shutter : Equipment
    {
        public Shutter(int id, String name, Boolean state, int number)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
        }

        public Shutter()
        {
            // TODO: Complete member initialization
        }

        override public Boolean update()
        {

            this.OpenWebNetGateway = OpenWebNetGateway.getInstance("172.16.0.209", 20000, OpenSocketType.Command);


            if (this.state)
            {
                this.AutomationUp(this.number.ToString());
            }
            else
            {
                this.AutomationDown(this.number.ToString());
            }

            //Mise a jour de la BDD
            CAD.SQLite db;

            db = CAD.SQLite.getInstance();
            int updatedRow = 0;
            String query = "UPDATE Shutter SET Name='" + this.Name + "', State='" + this.state + "' WHERE Id=" + this.Id + ";";

            updatedRow = db.ExecuteNonQuery(query);

            if (updatedRow > 0)
            {
                Console.WriteLine("shutter updated");
                return true;
            }
            else
            {
                Console.WriteLine("error: shutter not updated");
                return false;
            }

        }

        public Shutter add(int id_parent)
        {
            CAD.SQLite db;
            try
            {
                //Ajout du radiateur en base
                db = CAD.SQLite.getInstance();
                String InsertQuery = "INSERT INTO Shutter (Name, State, ID_Room, number) VALUES ('" + this.name + "', '" + this.state + "', '" + id_parent + "', '" + this.number + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id du radiator
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM Shutter";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }

                    //Creation de lobjet radiateur
                    if (id != 0)
                    {
                        this.id = id;
                        Console.WriteLine("New Shutter Created");
                        return this;
                    }
                    else
                    {
                        Console.WriteLine("Erreur Shutter dont added");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation Shutter");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation Shutter - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        /// <summary>
        /// Open shutter
        /// </summary>
        /// <param name="where">Specify the shutter to open</param>
        public void AutomationUp(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Automation, "1", where);
        }

        /// <summary>
        /// Abbassa il punto di Automazione
        /// </summary>
        /// <param name="where">Specify the shutter to open</param>
        public void AutomationDown(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Automation, "2", where);
        }

        /// <summary>
        /// Ferma il punto di Automazione
        /// </summary>
        /// <param name="where">Specifica il punto automazione da fermare</param>
        public void AutomationStop(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Automation, "0", where);
        }

        /// <summary>
        /// Richiede lo stato del punto automazione
        /// </summary>
        /// <param name="where">Specifica il punto automazione</param>
        public void AutomationGetStatus(string where)
        {
            OpenWebNetGateway.GetStateCommand(WHO.Automation, where);
        }

        override public void retrieveById(int id)
        {
            CAD.SQLite db;

            try
            {
                db = CAD.SQLite.getInstance();
                DataTable result;
                String query = "SELECT * FROM Shutter where ID = " + id + " LIMIT 1";
                result = db.GetDataTable(query);
                // boucle resultat requete
                foreach (DataRow r in result.Rows)
                {
                    this.id = id;
                    this.name = r["Name"].ToString();
                    this.state = Boolean.Parse(r["State"].ToString());
                    this.number = int.Parse(r["Number"].ToString());
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
            }
        }
    }
}
