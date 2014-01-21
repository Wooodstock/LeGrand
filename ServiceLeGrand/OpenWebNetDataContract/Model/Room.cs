using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceServiceLegrand.Model
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
        
        
        
        
        
    }
}
