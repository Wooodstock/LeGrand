using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceServiceLegrand.Model
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
        
        
    }
}
