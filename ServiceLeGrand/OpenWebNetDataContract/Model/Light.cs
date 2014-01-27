using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Gateway;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public class Light : Equipment
    {
        public Light(int id, String name, Boolean state, int number, int intensity)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
            this.intensity = intensity;
        }

        private int intensity;

        [DataMember]
        public int Intensity
        {
            get { return intensity; }
            set { intensity = value; }
        }

        /// <summary>
        /// Turn ON the specified light point
        /// </summary>
        /// <param name="where">Specify the light point to turn ON</param>
        public void LightingLightON(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Lighting, "1", where);
        }

        /// <summary>
        /// Turn OFF the light point specified
        /// </summary>
        /// <param name="where">Specify the light point to turn ON</param>
        public void LightingLightOFF(string where)
        {
            OpenWebNetGateway.SendCommand(WHO.Lighting, "0", where);
        }

        /// <summary>
        /// get the light point status
        /// </summary>
        /// <param name="dove">specify the light point</param>
        public void LightingGetLightStatus(string dove)
        {
            OpenWebNetGateway.GetStateCommand(WHO.Lighting, dove);
        }
        
    }
}
