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
        public Light(int id, String name, Boolean state, int number, int intensity)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
            this.intensity = intensity;
        }

        private int intensity;

        [DataMember]
        public int Intensity
        {
            get { return intensity; }
            set { intensity = value; }
        }

        public Light add(String name, Boolean state, int number, int intensity, int id_room)
        {
            CAD.SQLite db;
            try
            {
                //Ajout de l'user en base
                db = CAD.SQLite.getInstance();
                String InsertQuery = "INSERT INTO Light (Name, State, Intensity, Id_Room) VALUES ('" + name + "', '" + state + "', '" + number + "', '" + password + "');";
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
            }*/
            throw new NotImplementedException();
        }

        public Boolean update(Light light){
            Boolean currentState = true; //this.LightingGetLightStatus();

            if (currentState != light.state)
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
