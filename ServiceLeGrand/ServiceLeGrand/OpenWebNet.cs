using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using InterfaceServiceLegrand;
using System.Data;

namespace ServiceLeGrand
{
    public class OpenWebNet : IOpenWebNet
    {
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
            throw new NotImplementedException();
        }

        public User updateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool connectUser(string mail, string password)
        {
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
            throw new NotImplementedException();
        }

        #endregion
    }
}


