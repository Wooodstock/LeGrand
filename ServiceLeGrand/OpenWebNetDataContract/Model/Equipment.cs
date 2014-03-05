using OpenWebNetDataContract.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.CAD;
using System.Data;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    [KnownType(typeof(Alarm))]
    [KnownType(typeof(Light))]
    [KnownType(typeof(Shutter))]
    [KnownType(typeof(Radiator))]
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

        private OpenWebNetGateway openWebNetGateway;

        public OpenWebNetGateway OpenWebNetGateway
        {
            get { return openWebNetGateway; }
            set { openWebNetGateway = value; }
        }
        

        private SQLite sqLite;

        public SQLite SqLite
        {
            get { return sqLite; }
            set { sqLite = value; }
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

        abstract public void retrieveById(int id);
        
    }
}
