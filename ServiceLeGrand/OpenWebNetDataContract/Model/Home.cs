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

        public void addRoom(Room room)
        {
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
                                room.add(this.id);
                            }
                        }

                        Home home = new Home(id, name, rooms, surface, volume);
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



        public Boolean remove(Home home)
        {
            throw new NotImplementedException();
        }

        public Home update(Home home)
        {
            throw new NotImplementedException();
        }

        public void retrieveByUserId(int idUser)
        {
            CAD.SQLite db;
            try
            {
                db = CAD.SQLite.getInstance();

                DataTable result;
                String selectQuery = "SELECT * FROM Home WHERE  ID = (SELECT ID_Home FROM User Where Id = 1 LIMIT 1)";
                result = db.GetDataTable(selectQuery);
                Home home = new Home();

                foreach (DataRow r in result.Rows)
                {
                    home.id = int.Parse(r["Id"].ToString());
                    home.name = r["Name"].ToString();
                    home.surface = float.Parse(r["Surface"].ToString());
                    home.volume = float.Parse(r["Volume"].ToString());
                }

                //get all room id
                selectQuery = "SELECT Id FROM Rooms WHERE ID_Home = " + home.id + "";
                result = db.GetDataTable(selectQuery);
                List<Room> rooms = new List<Room>();

                foreach (DataRow r in result.Rows)
                {
                    Room room = new Room();
                    room.retrieveById(int.Parse(r["Id"].ToString()));
                    rooms.Add(room);
                }

                this.rooms = rooms;
            }
            catch (Exception fail)
            {
                String error = "Erreur retreive Home - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
            }
        }

    }
}
