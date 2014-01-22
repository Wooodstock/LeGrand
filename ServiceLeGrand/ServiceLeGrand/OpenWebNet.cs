using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using InterfaceServiceLegrand;
using ServiceLeGrand.WallAccess;

namespace ServiceLeGrand
{
    public class OpenWebNet : IOpenWebNet
    {
        private OpenWebNetGateway openWebNet;

        #region Services Home

        public Home addHome(List<Room> rooms, string name, float surface, float volume)
        {
            throw new NotImplementedException();
        }

        public bool removeHome(Home home)
        {
            throw new NotImplementedException();
        }

        public Home updateHome(Home home)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Service Legrand

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        public bool Connection(string mail, string password)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Services program

        public Program addProgram(string name, DateTime startHour, List<Day> workingDays, List<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public bool removeProgram(Program program)
        {
            throw new NotImplementedException();
        }

        public Program updateProgram(Program program)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Services Rooms

        public Room addRoom(string name, float surface, List<Equipment> equipments, Consumption consumption)
        {
            throw new NotImplementedException();
        }

        public bool removeRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Room updateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Services Equipement

        public Equipment addEquipment(string name, bool state, float temperature, int intensity)
        {
            throw new NotImplementedException();
        }

        public bool removeEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public Equipment updateEquipment(Equipment equipment)
        {

            if (equipment is Radiator) {
                // ########## The DataBase Side ###########
                // TODO

                // ##########  The Wall Side ###########
                // TODO
            }
            else if (equipment is Light) {
                // ########## The DataBase Side ###########
                // TODO
                


                // ##########  The Wall Side ###########
                // TODO

                Light light = (Light)equipment;

                Boolean stateChanged = true; // 
                /* Soit vérifié état de l'object courant par rapport a celui en base
                 * soit vérifié état de l'équipement avec le mur.
                 * /

                if (!light.State && stateChanged)
                {
                    openWebNet.LightingLightOFF(light.Number.ToString());
                }
                else { 
                    openWebNet.LightingLightON(light.Number.ToString());
                }
                

            }
            else if (equipment is Shutter) {
                // ########## The DataBase Side ###########
                // TODO

                // ##########  The Wall Side ###########
                // TODO
            
            } 
            else if (equipment is Alarm){
                // ########## The DataBase Side ###########
                // TODO

                // ##########  The Wall Side ###########
                // TODO
                
            }

            throw new NotImplementedException();
        }

        #endregion

        #region Services User

        public User addUser(string name, string surname, string mail, string password)
        {
            throw new NotImplementedException();
        }

        public bool removeUser(User user)
        {
            throw new NotImplementedException();
        }

        public User updateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool connectUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool logout()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


