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
        Boolean haveRespond = false;
        String response;

        public Light(int id, String name, Boolean state, int number, int intensity) : base(id, name, state, number)
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

        public Light add(int id_parent)
        {
            CAD.SQLite db;
            try
            {
                //Ajout de la light en base
                db = CAD.SQLite.getInstance();
                String InsertQuery = "INSERT INTO Light (Name, State, Intensity, ID_Room, Number) VALUES ('" + this.name + "', '" + this.state + "', '" + this.intensity + "', '" + id_parent + "', '" + this.number + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id de la light
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT ID FROM Light";
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

        public void callback(object sender, OpenWebNetDataEventArgs e)
        {
            this.haveRespond = true;
            this.response = e.Data;
            Console.WriteLine("I'm back");
        }

        public void callbackError(object sender, OpenWebNetErrorEventArgs e)
        {
            this.haveRespond = true;
            Console.WriteLine("Error during Wall connection : "+ e.Exception.Message);
        }

        public Boolean update() {

            this.OpenWebNetGateway = OpenWebNetGateway.getInstance("172.16.0.209", 20000, OpenSocketType.Command);


            if (this.state)
            {
                this.LightingLightON(this.number.ToString());
            }
            else {
                this.LightingLightOFF(this.number.ToString());
            }

            //Mise a jour de la BDD
            CAD.SQLite db;

            db = CAD.SQLite.getInstance();
            int updatedRow = 0;
            String query = "UPDATE Light SET Name=" + this.Name + ", State=" + this.state + ", Intensity =" + this.intensity + " WHERE Id=" + this.Id + ";";

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

        public Boolean update(Light light){
            this.haveRespond = false;
            this.response = null;
            this.OpenWebNetGateway.DataReceived += new EventHandler<OpenWebNetDataEventArgs>(callback);
            this.OpenWebNetGateway.ConnectionError += new EventHandler<OpenWebNetErrorEventArgs>(callbackError);
            
            this.LightingGetLightStatus(light.number.ToString());
           
            while (!this.haveRespond)
            {
                Console.WriteLine("I'm waiting");
            }
            // Do Return process :
            if (this.response != null) { 
                
            }

            this.OpenWebNetGateway.DataReceived -= new EventHandler<OpenWebNetDataEventArgs>(callback);
            this.OpenWebNetGateway.ConnectionError -= new EventHandler<OpenWebNetErrorEventArgs>(callbackError);

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
        public void LightingLightON(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Lighting, "1", where);
        }

        /// <summary>
        /// Turn OFF the light point specified
        /// </summary>
        /// <param name="where">Specify the light point to turn ON</param>
        public void LightingLightOFF(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Lighting, "0", where);
        }

        /// <summary>
        /// get the light point status
        /// </summary>
        /// <param name="dove">specify the light point</param>
        public void LightingGetLightStatus(string where)
        {
            OpenWebNetGateway.GetStateCommand(WHO.Lighting, where);
        }
    }
}
