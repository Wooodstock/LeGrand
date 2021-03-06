﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using InterfaceServiceLegrand;
using ServiceLeGrand.WallAccess;
using System.Data;

namespace ServiceLeGrand
{
    public class OpenWebNet : IOpenWebNet
    {
        private Home home;
        private User user;
        private OpenWebNetGateway openWebNet;


        #region Services Home

        public Home addHome(List<Room> rooms, string name, float surface, float volume)
        {
            CAD.SQLite db;

            try
            {
                db = new CAD.SQLite();
                String querry = "INSERT INTO Home (Name, Surface, Volume) VALUES ('" + name + "', '" + surface + "', '" + volume + "')";
                int updatedRow = 0;

                updatedRow = db.ExecuteNonQuery(querry);

                if (updatedRow > 0)
                {
                    //recuperation de lid
                    DataTable result;
                    String selectQuery = "SELECT Id FROM Home";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }

                    //Creation de lobjet Home
                    if (id != 0)
                    {
                        Home home = new Home(id, name, rooms, surface, volume);
                        Console.WriteLine("New Home Created");
                        return home;
                    }
                    else
                    {
                        Console.WriteLine("Erreur creation Home");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation Home");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation User - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }

        }

        public bool removeHome(Home home)
        {
            CAD.SQLite db;

            try
            {
                db = new CAD.SQLite();
                int updatedRow = 0;
                String query = "DELETE FROM Home WHERE Id = " + user.Id + ";";

                updatedRow = db.ExecuteNonQuery(query);
                if (updatedRow > 0)
                {
                    Console.WriteLine("Home deleted");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: Home was not deleted");
                    return false;
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }
        }

        public Home updateHome(Home home)
        {
            //Lister les pieces et update

            //BDD

            //
            CAD.SQLite db;
            try
            {
                db = new CAD.SQLite();
                int updatedRow = 0;
                String query = "UPDATE HOME SET Name=" + user.Name + ", Surface=" + user.Surname + ", Volume=" + user.Mail + ", Password=" + user.Password + " WHERE Id=" + user.Id + ";";

                updatedRow = db.ExecuteNonQuery(query);

                if (updatedRow > 0)
                {
                    Console.WriteLine("user updated");
                    return true;
                }
                else
                {
                    Console.WriteLine("error: user not updated");
                    return false;
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }

            //WALL



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
            /*
            CAD.SQLite db;

            try
            {
                db = new CAD.SQLite();
                String querry = "INSERT INTO Room (Name, Surface, )"

            }
             * */

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

                Boolean stateChanged = true; 
                /* Soit vérifié état de l'object courant par rapport a celui en base
                 * soit vérifié état de l'équipement avec le mur.
                 */

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
            CAD.SQLite db;

            //TODO: Check if user deja en base

            try
            {
                //Ajout de l'user en base
                db = new CAD.SQLite();
                String InsertQuery = "INSERT INTO User (Name, Surname, Mail, Password) VALUES ('" + name + "', '" + surname + "', '" + mail + "', '" + password + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id de l'user (mail doit etre unique)
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM User WHERE Mail = '" + mail + "'";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }

                    //Creation de lobjet User
                    if (id != 0)
                    {
                        User user = new User(id, name, surname, mail, password);
                        Console.WriteLine("New User Created");
                        return user;
                    }
                    else
                    {
                        Console.WriteLine("Erreur creation User");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation User");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation User - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        public bool removeUser(User user)
        {
            CAD.SQLite db;

            try
            {
                db = new CAD.SQLite();
                int updatedRow = 0;
                String query = "DELETE FROM User WHERE Id = "+ user.Id +";";

                updatedRow = db.ExecuteNonQuery(query);
                if (updatedRow > 0)
                {
                    Console.WriteLine("User deleted");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: User was not deleted");
                    return false;
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }
        }

        public Boolean updateUser(User user)
        {
            CAD.SQLite db;
            try
            {
                db = new CAD.SQLite();
                int updatedRow = 0;
                String query = "UPDATE User SET Name=" + user.Name + ", Surname=" + user.Surname + ", Mail=" + user.Mail + ", Password=" + user.Password + " WHERE Id=" + user.Id + ";";

                updatedRow = db.ExecuteNonQuery(query);

                if (updatedRow > 0)
                {
                    Console.WriteLine("user updated");
                    return true;
                }
                else
                {
                    Console.WriteLine("error: user not updated");
                    return false;
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }
        }

        public Boolean connectUser(string mail, string password)
        {

            //TODO: Return user & this.user = user;

            CAD.SQLite db;
            String dbPassword;

            try
            {
                db = new CAD.SQLite();
                DataTable result;
                String query = "SELECT Password FROM User WHERE Mail = '" + mail + "'";
                result = db.GetDataTable(query);
                dbPassword = "password";

                // boucle resultat reauete
                foreach (DataRow r in result.Rows)
                {
                    dbPassword = r["Password"].ToString();
                }

                if (password.Equals(dbPassword))
                {
                    Console.WriteLine("User " + mail + " connected");
                    //Connexionn SUCCES
                    return true;
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return false;
            }
            return false;
        }

        public bool logout()
        {
            this.user = null;
            return true;
        }

        #endregion
    }
}


