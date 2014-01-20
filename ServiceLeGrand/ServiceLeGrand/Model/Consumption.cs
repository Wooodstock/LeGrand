using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.Model
{
    class Consumption
    {
        public Consumption()
        {

        }

        public Consumption(String electrical, String gaz)
        {
            this.electrical = electrical;
            this.gaz = gaz;
        }

        private String electrical;

        public String Electrical
        {
            get { return electrical; }
            set { electrical = value; }
        }

        private String gaz;

        public String Gaz
        {
            get { return gaz; }
            set { gaz = value; }
        }
        
        
    }
}
