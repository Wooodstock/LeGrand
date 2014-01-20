using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.Model
{
    class Radiator : Equipment
    {
        public Radiator(int id, String name, Boolean state, int number, float temperature)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
            this.temperature = temperature;
        }

        private float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
    }
}
