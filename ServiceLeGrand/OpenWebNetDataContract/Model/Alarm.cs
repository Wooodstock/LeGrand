using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.Model
{
    [DataContract]
    class Alarm : Equipment
    {
        public Alarm(int id, String name, Boolean state, int number)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
        }
    }
}
