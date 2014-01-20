using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.Model
{
    class Home
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

        private List<Room> rooms;

        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        private float surface;

        public float Surface
        {
            get { return surface; }
            set { surface = value; }
        }

        private float volume;

        public float Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        
        
    }
}
