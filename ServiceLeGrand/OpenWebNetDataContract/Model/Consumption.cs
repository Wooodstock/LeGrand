using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public class Consumption
    {
        public Consumption()
        {

        }

        public Consumption(int id, String electrical, String gaz)
        {
            this.id = id;
            this.electrical = electrical;
            this.gaz = gaz;
        }

        [DataMember]
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        private String electrical;

        public String Electrical
        {
            get { return electrical; }
            set { electrical = value; }
        }

        [DataMember]
        private String gaz;

        public String Gaz
        {
            get { return gaz; }
            set { gaz = value; }
        }
        
        
    }
}
