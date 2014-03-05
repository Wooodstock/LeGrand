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
                
            
            }


            //Création Home
            Home loicHome = new Home(0, "La Maison de Loic", new List<Room>(), (float)150, (float)1500);

            Room cuisine = new Room(0, "Cuisine", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));

            cuisine.addEquipment(new Light(0, "Light1", false, 1, 50));
            cuisine.addEquipment(new Light(1, "Light2", false, 2, 50));
            cuisine.addEquipment(new Light(2, "Light3", false, 3, 50));

            Room salleDeBain = new Room(0, "Salle de Bain", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
              
            salleDeBain.addEquipment(new Light(0, "Light1", false, 1, 50));
            salleDeBain.addEquipment(new Light(0, "Light2", false, 2, 50));
            salleDeBain.addEquipment(new Light(0, "Light3", false, 3, 50));
              
            Room salon = new Room(0, "Salon", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
              
            salon.addEquipment(new Light(0, "Light1", false, 1, 50));
            salon.addEquipment(new Light(0, "Light2", false, 2, 50));
            salon.addEquipment(new Light(0, "Light3", false, 3, 50));
              
            loicHome.addRoom(cuisine);
            loicHome.addRoom(salleDeBain);
            loicHome.addRoom(salon);
            return loicHome;
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
                case ("lightOn"): 
                    Light light = (Light)equipment;
                    light.update();
                    break;
                case ("lightOff"):
                    Light light2 = (Light)equipment;
                    light2.update();
                    break;
                case ("shutterUp"):
                    Shutter shutterUp = (Shutter)equipment;
                    shutterUp.update();
                    break;
                case ("shutterDown"):
                    Shutter shutterDown = (Shutter)equipment;
                    shutterDown.update();
                    break;
            }
            return null;
        }
    }
}
