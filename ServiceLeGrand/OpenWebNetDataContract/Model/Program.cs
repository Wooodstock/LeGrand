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
    public class Program
    {
        public Program()
        {

        }

        public Program(int id, String name, DateTime startHour, List<Day> workingDays, List<Room> rooms)
        {
            this.id = id;
            this.name = name;
            this.startHour = startHour;
            this.workingDays = workingDays;
            this.rooms = rooms;
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
        private DateTime startHour;

        public DateTime StartHour
        {
            get { return startHour; }
            set { startHour = value; }
        }

        [DataMember]
        private List<Day> workingDays;

        public List<Day> WorkingDays
        {
            get { return workingDays; }
            set { workingDays = value; }
        }

        [DataMember]
        private List<Room> rooms;

        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        Program add(String name, DateTime startHour, List<Day> workingDays, List<Room> rooms)
        {
            CAD.SQLite db;

            //TODO: Check if user deja en base

            try
            {
                //Ajout de l'user en base
                db = new CAD.SQLite();
                String startHourFormat = startHour.ToString("yyyy-MM-dd HH:mm:ss");
                String InsertQuery = "INSERT INTO Program (Name, StartHour) VALUES ('" + name + "', '" + startHourFormat + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id du programme (name doit etre unique)
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM Program WHERE name = '" + name + "'";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }

                    //Creation de lobjet Program
                    if (id != 0)
                    {


                        Program program = new Program(id, name, startHour, null, null);
                        Console.WriteLine("New Program Created");
                        return program;
                    }
                    else
                    {
                        Console.WriteLine("Erreur creation Program");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation Program");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation Program - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        Boolean remove(Program program)
        {
            throw new NotImplementedException();
        }

        Program update(Program program)
        {
            throw new NotImplementedException();
        }
        
        
    }
}
