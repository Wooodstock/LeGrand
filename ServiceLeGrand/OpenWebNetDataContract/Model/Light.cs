using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract;
using OpenWebNetDataContract.Gateway;
using System.Data;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public class Light : Equipment
    {
        public Light(int id, String name, Boolean state, int number, int intensity, Room parent) : base(id, name, state, number, parent)
        {
            this.intensity = intensity;
        }

        private int intensity;

        [DataMember]
        public int Intensity
        {
            get { return intensity; }
            set { intensity = value; }
        }

        public Light add()
        {
            CAD.SQLite db;
            try
            {
                //Ajout de la light en base
                db = CAD.SQLite.getInstance();
                String InsertQuery = "INSERT INTO Light (Name, State, Intensity, Id_Room, Number) VALUES ('" + this.name + "', '" + this.state + "', '" + this.intensity + "', '" + this._Parent.Id + "', '"+ this.number +"');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id de la light
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM Light";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }

                    //Creation de lobjet light
                    if (id != 0)
                    {
                        this.id = id;
                        Console.WriteLine("New Light Created");
                        return this;
                    }
                    else
                    {
                        Console.WriteLine("Erreur creation light");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation light");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation light - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        public Boolean update(Light light){
            //Boolean currentState = true; //this.LightingGetLightStatus();

            if (this.state != light.state)
            {
                try
                {
                    //Mise a jour du WALL
                    switch (light.state)
                    {
                        case true:
                            this.LightingLightON(light.number.ToString());
                            break;

                        case false:
                            this.LightingLightOFF(light.number.ToString());
                            break;
                    }
                    //Mise a jour de la BDD
                    CAD.SQLite db;
               
                    db = CAD.SQLite.getInstance();
                    int updatedRow = 0;
                    String query = "UPDATE Light SET Name=" + light.Name + ", State=" + light.state + ", Intensity =" + light.intensity + " WHERE Id=" + light.Id + ";";

                    updatedRow = db.ExecuteNonQuery(query);

                    if (updatedRow > 0)
                    {
                        Console.WriteLine("Light updated");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("error: Light not updated");
                        return false;
                    }
                }
                catch (Exception fail)
                {
                    String error = "ERROR LIGHT: The following error has occurred:\n\n";
                    error += fail.Message.ToString() + "\n";
                    Console.WriteLine(error);
                    return false;
                }
            }
            return true;
        }

        public Boolean removeLight(Light light)
        {
            CAD.SQLite db;

            try
            {
                db = CAD.SQLite.getInstance();
                int updatedRow = 0;
                String query = "DELETE FROM Light WHERE Id = " + light.Id + ";";

                updatedRow = db.ExecuteNonQuery(query);
                if (updatedRow > 0)
                {
                    Console.WriteLine("Light deleted");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: Light was not deleted");
                    return false;
                }
            }
            catch (Exception fail)
            {
                String error = "Error Light: The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }
        }

   
        /// <summary>
        /// Turn ON the specified light point
        /// </summary>
        /// <param name="where">Specify the light point to turn ON</param>
        private void LightingLightON(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Lighting, "1", where);
        }

        /// <summary>
        /// Turn OFF the light point specified
        /// </summary>
        /// <param name="where">Specify the light point to turn ON</param>
        private void LightingLightOFF(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Lighting, "0", where);
        }

        /// <summary>
        /// get the light point status
        /// </summary>
        /// <param name="dove">specify the light point</param>
        private void LightingGetLightStatus(string where)
        {
            OpenWebNetGateway.GetStateCommand(WHO.Lighting, where);
        }
    }
}
