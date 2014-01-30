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
    public class Home
    {
        public Home()
        {

        }


        public Home(int id, String name, List<Room> rooms, float surface, float volume)
        {
            this.id = id;
            this.name = name;
            this.rooms = rooms;
            this.surface = surface;
            this.volume = volume;
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
        private List<Room> rooms;

        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        [DataMember]
        private float surface;

        public float Surface
        {
            get { return surface; }
            set { surface = value; }
        }

        [DataMember]
        private float volume;

        public float Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public void addRoom(Room room) {
            this.rooms.Add(room);
        }

        public Home add(List<Room> rooms, String name, float surface, float volume)
        {
            CAD.SQLite db;
            try
            {
                db = CAD.SQLite.getInstance();


                String InsertQuery = "INSERT INTO Home (Name, Surface , Volume) VALUES ('" + name + "', '" + surface + "', '" + volume + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id de l'user (mail doit etre unique)
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM Home WHERE name = '" + name + "'";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }



                    //Creation de lobjet Home et link avec Room
                    if (id != 0)
                    {
                        this.id = id;
                        if (rooms != null && rooms.Count > 0)
                        {
                            foreach (Room room in rooms)
                            {
                                room.add();
                            }
                        }

                        Home home = new Home(id, name, rooms, surface,volume);
                        Console.WriteLine("New Home Created");
                        return home;
                    }
                    else
                    {
                        Console.WriteLine("Erreur creation Home");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation Home");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation Home - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        Boolean remove(Home home)
        {
            throw new NotImplementedException();
        }

        Home update(Home home)
        {
            throw new NotImplementedException();
        }
        
    }
}
