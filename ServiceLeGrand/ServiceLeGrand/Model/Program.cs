using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.Model
{
    class Program
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

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime startHour;

        public DateTime StartHour
        {
            get { return startHour; }
            set { startHour = value; }
        }

        private List<Day> workingDays;

        public List<Day> WorkingDays
        {
            get { return workingDays; }
            set { workingDays = value; }
        }

        private List<Room> rooms;

        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }
        
        
        
        
        
    }
}
