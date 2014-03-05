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

        public Boolean update() { 
            /*
             * Mettre à jour en fonction de state : 1 ouvert, 0 fermé
             * 
             */
            throw new NotImplementedException();
        
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
    }
}
