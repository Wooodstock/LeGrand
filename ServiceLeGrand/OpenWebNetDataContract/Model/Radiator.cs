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
    public class Radiator : Equipment
    {
        public Radiator(int id, String name, Boolean state, int number, float temperature, Room parent) : base(id, name, state, number, parent)
        {
            this.temperature = temperature;
        }

        [DataMember]
        private float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public Radiator add()
        {
            CAD.SQLite db;
            try
            {
                //Ajout du radiateur en base
                db = CAD.SQLite.getInstance();
                String InsertQuery = "INSERT INTO Radiator (Name, State, Temperature, Id_Room, Number) VALUES ('" + this.name + "', '" + this.state + "', '" + this.temperature + "', '" + this._Parent.Id + "', '" + this.number + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id du radiator
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM Radiator";
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
                        Console.WriteLine("New Radiator Created");
                        return this;
                    }
                    else
                    {
                        Console.WriteLine("Erreur Radiator dont added");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation radiator");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation radiator - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        public Boolean update(Radiator radiator)
        {
            if (this.state != radiator.state || this.temperature != radiator.temperature)
            {
                try
                {
                    //Mise a jour du WALL
                    switch (radiator.state)
                    {
                        case true:
                            //ALLUMER RADIATOR
                            break;

                        case false:
                            //ETEINDRE RADIATOR
                            break;
                    }
                    //Mise a jour de la BDD
                    CAD.SQLite db;

                    db = CAD.SQLite.getInstance();
                    int updatedRow = 0;
                    String query = "UPDATE Radiator SET Name=" + radiator.Name + ", State=" + radiator.state + ", Temperature =" + radiator.temperature + " WHERE Id=" + this.Id + ";";

                    updatedRow = db.ExecuteNonQuery(query);

                    if (updatedRow > 0)
                    {
                        this.name = radiator.name;
                        this.state = radiator.state;
                        this.temperature = radiator.temperature;
                        this.number = radiator.number;
                        Console.WriteLine("Radiator updated");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("error: Radiator not updated");
                        return false;
                    }
                }
                catch (Exception fail)
                {
                    String error = "ERROR Radiator: The following error has occurred:\n\n";
                    error += fail.Message.ToString() + "\n";
                    Console.WriteLine(error);
                    return false;
                }
            }
            return true;
        }



        public void HeatingSetZoneAuto(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Heating, "311", string.Format("#{0}", where));
        }

        public void HeatingSetZoneOFF(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Heating, "303", string.Format("#{0}", where));
        }
    }
}
