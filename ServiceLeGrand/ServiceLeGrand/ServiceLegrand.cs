using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using InterfaceServiceLegrand;

namespace ServiceLegrand
{
    public class ServiceLegrand : IServiceLegrand
    {
        /*
         * order :  "getHome"
         * return the Home in base for user connected
         *  dico['user'] return an User object
         * 
         */

        public Home serviceHome(string order, Home home, Dictionary<object, object> dico) {

            // Si l'order est de retourner la maison et que l'utilisateur est connected
            if (order.Equals("getHome") && (int)dico["connected"] > 0) {
                home.retrieveByUserId((int)dico["connected"]);
            }
            
            return home;
        }

        /*
         * order :  "getProgram"
         * return the Home in base for user connected
         *  dico['user'] return an User object
         * 
         */

        public Program serviceProgram(string order, Program program, Dictionary<object, object> dico)
        {


            return program;
        }

        /*
         * order = "connect"
         * return user if succeed, null if failed
         * 
         * 
         */

        public Dictionary<object, object> serviceUser(string order, User user, Dictionary<object, object> dico)
        {
            if (order.Equals("connect")) {
                dico["connected"] = user.connect();
            }
            return dico;
        }

        /*
         * order = "lightOn"
         * allume light de l'équipement envoyé
         * 
         * 
         * order = "lightOff"
         * éteint light de l'équipement envoyé
         * 
         * order = "shutterUp"
         * Ouvre volet
         * 
         * order = "shutterDown"
         * ferme volet
         * 
         */

        public Equipment serviceEquipment(string order, Equipment equipment, Dictionary<object, object> dico)
        {
            switch(order){
                case ("switch"):
                    equipment.update();
                    break;
                case ("shutterUp"):
                    equipment.update();
                    break;
                case ("shutterDown"):
                    equipment.update();
                    break;
            }
            return equipment;
        }
    }
}
