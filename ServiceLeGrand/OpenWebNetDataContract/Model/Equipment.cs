using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public abstract class Equipment
    {
        public Equipment()
        {
        }

        public Equipment(int id, String name, Boolean state, int number)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
        }

        [DataMember]
        protected int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        protected String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        protected Boolean state;

        public Boolean State
        {
            get { return state; }
            set { state = value; }
        }

        [DataMember]
        protected int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        Equipment add(String name, Boolean state, float temperature, int intensity)
        {
            throw new NotImplementedException();
        }

        Boolean remove(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        Equipment update(Equipment equipment)
        {

            if (equipment is Radiator)
            {
                // ########## The DataBase Side ###########
                // TODO

                // ##########  The Wall Side ###########
                // TODO
            }
            else if (equipment is Light)
            {
                // ########## The DataBase Side ###########
                // TODO



                // ##########  The Wall Side ###########
                // TODO

            }
            else if (equipment is Shutter)
            {
                // ########## The DataBase Side ###########
                // TODO

                // ##########  The Wall Side ###########
                // TODO

            }
            else if (equipment is Alarm)
            {
                // ########## The DataBase Side ###########
                // TODO

                // ##########  The Wall Side ###########
                // TODO

            }

            throw new NotImplementedException();
        }
        
        
    }
}
