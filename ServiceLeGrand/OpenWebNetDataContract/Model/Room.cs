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
    public class Room
    {

        public Room()
        {

        }

        public Room(int id, String name, float surface, List<Equipment> equipments, Consumption consumption)
        {
            this.id = id;
            this.name = name;
            this.surface = surface;
            this.equipments = equipments;
            this.consumption = consumption;
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
        private float surface;

        public float Surface
        {
            get { return surface; }
            set { surface = value; }
        }

        [DataMember]
        private List<Equipment> equipments;

        public List<Equipment> Equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }

        [DataMember]
        private Consumption consumption;

        public Consumption Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }


        // Ajoute un equipement a la liste de room
        public void addEquipment(Equipment equipment) {
            this.equipments.Add(equipment);
        }

        public Room add(int id_parent)
        {
            CAD.SQLite db;
            try
            {
                //Ajout de la room en base
                db = CAD.SQLite.getInstance();

                String InsertQuery = "INSERT INTO Room (Name, Surface, ID_Home) VALUES ('" + this.name + "', '" + this.surface + "', '" + id_parent + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id de la room (mail doit etre unique)
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM Room WHERE name = '" + name + "'";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }



                    //Creation de lobjet Room et link avec Equipement
                    if (id != 0)
                    {
                        this.id = id;
                        if (equipments != null && equipments.Count > 0)
                        {
                            foreach (Equipment equipment in equipments)
                            {
                                if (equipment is Radiator)
                                {
                                    Radiator radiator = (Radiator)equipment;
                                    radiator.add(this.id);
                                }
                                else if (equipment is Light)
                                {
                                    Light light = (Light)equipment;
                                    light.add(this.id);
                                }
                                else if (equipment is Shutter)
                                {
                                    Shutter shutter = (Shutter)equipment;
                                    shutter.add(this.id);
                                }
                                else if (equipment is Alarm)
                                {
                                    Alarm alarm = (Alarm)equipment;
                                    InsertQuery = "INSERT INTO Alarm (ID_Room) VALUES ('" + id + "') WHERE ID = '" + alarm.Id + "';";
                                    rowsUpdated = db.ExecuteNonQuery(InsertQuery);
                                    if (rowsUpdated > 0)
                                    {
                                        Console.WriteLine("Alarm " + alarm.Id + " updated");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to link Alarm with Room");
                                    }
                                }
                            }

                            if (consumption != null) {
                                InsertQuery = "INSERT INTO Consumption (ID_Room) VALUES ('" + id + "') WHERE ID = '" + consumption.Id + "';";
                                rowsUpdated = db.ExecuteNonQuery(InsertQuery);
                                if (rowsUpdated > 0)
                                {
                                    Console.WriteLine("Consumption " + consumption.Id + " updated");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to link Consumption with Room");
                                }
                            }
                        }

                        this.id = id;
                        Console.WriteLine("New Room Created");
                        return this;
                    }
                    else
                    {
                        Console.WriteLine("Erreur creation Room");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation Room");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation Room - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        public bool remove()
        {
            CAD.SQLite db;

            try
            {
                db = CAD.SQLite.getInstance();
                int updatedRow = 0;
                String query = "DELETE FROM Room WHERE Id = " + this.Id + ";";

                updatedRow = db.ExecuteNonQuery(query);
                if (updatedRow > 0)
                {
                    Console.WriteLine("Room deleted");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: Room was not deleted");
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

        public Boolean update()
        {
            CAD.SQLite db;
            try
            {
                db = CAD.SQLite.getInstance();
                int updatedRow = 0;
                String query = "UPDATE Room SET Name='" + this.Name + "';";

                updatedRow = db.ExecuteNonQuery(query);

                if (updatedRow > 0)
                {
                    Console.WriteLine("Room updated");
                    return true;
                }
                else
                {
                    Console.WriteLine("error: room not updated");
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

        public void retrieveById(int id)
        {
            CAD.SQLite db;

            try
            {
                db = CAD.SQLite.getInstance();
                DataTable result;
                String query = "SELECT * FROM Room where ID = '"+id+"' LIMIT 1";
                result = db.GetDataTable(query);
                // boucle resultat requete
                foreach (DataRow r in result.Rows)
                {
                    this.id = id;
                    this.name = r["Name"].ToString();
                    this.surface = float.Parse(r["Surface"].ToString());
                }

                //Retrieve All Equipement
                List<Equipment> equipments = new List<Equipment>();
                //get all LIGHT
                query = "SELECT * FROM Light WHERE ID_Room = "+ id +"";
                result = db.GetDataTable(query);
                
                foreach (DataRow r in result.Rows)
                {
                    Equipment equipment = new Light();
                    equipment.retrieveById(int.Parse(r["ID"].ToString()));
                    equipments.Add(equipment);
                }

                //get all Shutter
                query = "SELECT * FROM Shutter WHERE ID_Room = " + id + "";
                result = db.GetDataTable(query);

                foreach (DataRow r in result.Rows)
                {
                    Equipment equipment = new Shutter();
                    equipment.retrieveById(int.Parse(r["ID"].ToString()));
                    equipments.Add(equipment);
                } 
 
                this.equipments = equipments;
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
