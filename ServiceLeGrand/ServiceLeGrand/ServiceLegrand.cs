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
        public Home serviceHome(string order, Home home, Dictionary<object, object> dico) {
            //Création Home
            Home loicHome = new Home(0, "La Maison de Loic", new List<Room>(), (float)150, (float)1500);

            Room cuisine = new Room(0, "Cuisine", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));

            cuisine.addEquipment(new Light(0, "Light1", false, 1, 50));
            cuisine.addEquipment(new Light(1, "Light2", false, 2, 50));
            cuisine.addEquipment(new Light(2, "Light3", false, 3, 50));

            Room salleDeBain = new Room(1, "Salle de Bain", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
              
            salleDeBain.addEquipment(new Light(0, "Light1", false, 1, 50));
            salleDeBain.addEquipment(new Light(0, "Light2", false, 2, 50));
            salleDeBain.addEquipment(new Light(0, "Light3", false, 3, 50));
              
            Room salon = new Room(2, "Salon", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
              
            salon.addEquipment(new Light(0, "Light1", false, 1, 50));
            salon.addEquipment(new Light(0, "Light2", false, 2, 50));
            salon.addEquipment(new Light(0, "Light3", false, 3, 50));
              
            loicHome.addRoom(cuisine);
            loicHome.addRoom(salleDeBain);
            loicHome.addRoom(salon);
            return loicHome;
        }

        public Equipment serviceEquipment(string order, Home home, Dictionary<object, object> dico) {
            throw new NotImplementedException();
        }

        public List<Program> serviceProgram(string order, Program program, Dictionary<object, object> dico) {

            #region Days
            Day lundi = new Day{ Id = 1, Name = "Lundi" };
            Day mardi = new Day{ Id = 2, Name = "Mardi" };
            Day mercredi = new Day{ Id = 3, Name = "Mercredi" };
            Day jeudi = new Day{ Id = 4, Name = "Jeudi" };
            Day vendredi = new Day{ Id = 5, Name = "Vendredi" };
            Day samedi = new Day{ Id = 6, Name = "Samedi" };
            Day dimanche = new Day{ Id = 7, Name = "Dimanche" };
            #endregion

            #region Rooms
            Room cuisine = new Room(0, "Cuisine", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));

            cuisine.addEquipment(new Light(0, "Light1", false, 1, 50));
            cuisine.addEquipment(new Light(1, "Light2", false, 2, 50));
            cuisine.addEquipment(new Light(2, "Light3", false, 3, 50));

            Room salleDeBain = new Room(1, "Salle de Bain", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
              
            salleDeBain.addEquipment(new Light(0, "Light1", false, 1, 50));
            salleDeBain.addEquipment(new Light(0, "Light2", false, 2, 50));
            salleDeBain.addEquipment(new Light(0, "Light3", false, 3, 50));
              
            Room salon = new Room(2, "Salon", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
              
            salon.addEquipment(new Light(0, "Light1", false, 1, 50));
            salon.addEquipment(new Light(0, "Light2", false, 2, 50));
            salon.addEquipment(new Light(0, "Light3", false, 3, 50));
            #endregion

            List<Day> semaine = new List<Day> { lundi, mardi, mercredi, jeudi, vendredi, samedi, dimanche };
            List<Room> rooms = new List<Room> { cuisine, salleDeBain, salon };
            
            #region Programs
            Program program1 = new Program(0, "Programme 1", DateTime.Now, semaine, rooms);
            Program program2 = new Program(1, "Programme 2", DateTime.Now, semaine, rooms);
            Program program3 = new Program(2, "Programme 3", DateTime.Now, semaine, rooms);
            #endregion

            List<Program> programs = new List<Program> { program1, program2, program3 };

            return programs;
        }

        public User serviceUser(string order, User program, Dictionary<object, object> dico) {
            throw new NotImplementedException();
        }
    }
}
