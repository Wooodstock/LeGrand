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
    public class Day
    {

        public Day()
        {

        }

        public Day(int id, String name)
        {
            this.id = id;
            this.name = name;
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

        public DayOfWeek dayInWeek() {

            if (this.name == "Lundi"){
                return DayOfWeek.Monday;
            } else if(this.name == "Mardi"){
                return DayOfWeek.Tuesday;
            } else if (this.name == "Mercredi") {
                return DayOfWeek.Wednesday;
            } else if (this.name == "Jeudi") {
                return DayOfWeek.Thursday;
            } else if (this.name == "Vendredi"){
                return DayOfWeek.Friday;
            } else if (this.name == "Samedi"){
                return DayOfWeek.Saturday;
            } else if (this.name == "Dimanche"){
                return DayOfWeek.Sunday;
            }
            return DayOfWeek.Sunday;
        }

        public static void retrieveById(int id)
        {
            CAD.SQLite db;

            try
            {
                db = CAD.SQLite.getInstance();
                DataTable result;
                String query = "SELECT * FROM Programed_Day where ID_program = '" + id + "'";
                result = db.GetDataTable(query);

                List<int> daysId = new List<int>();
                // boucle resultat requete
                foreach (DataRow r in result.Rows)
                {
                    daysId.Add(int.Parse(r["ID_Day"].ToString()));
                }

                //Retrieve All Days
                List<Day> days = new List<Day>();
                foreach (int idDay in daysId) {
                    query = "SELECT * FROM Day WHERE ID = " + id + " LIMIT 1";
                    result = db.GetDataTable(query);

                    foreach (DataRow r in result.Rows)
                    {
                        days.Add(new Day { id = idDay, name = r["Name"].ToString() });
                    }
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


