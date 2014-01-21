using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceServiceLegrand.Model
{
    [DataContract]
    public class Consumption
    {
        public Consumption()
        {

        }

        public Consumption(String electrical, String gaz)
        {
            this.electrical = electrical;
            this.gaz = gaz;
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
