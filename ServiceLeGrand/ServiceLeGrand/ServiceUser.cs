using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using InterfaceServiceLegrand.Model;
using InterfaceServiceLegrand;

namespace ServiceLeGrand
{
    public class ServiceUser : IServiceUser
    {
        public User addUser(String name, String surname, String mail, String password)
        {
            throw new NotImplementedException();
        }

        public Boolean removeUser(User user)
        {
            throw new NotImplementedException();
        }

        public User updateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Boolean connectUser(String login, String password)
        {
            throw new NotImplementedException();
        }

        public Boolean logout()
        {
            throw new NotImplementedException();
        }
    }
}
