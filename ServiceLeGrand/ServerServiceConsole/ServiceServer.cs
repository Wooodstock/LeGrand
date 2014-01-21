using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace OpenWebNetWinForm
{
    class ServiceServer
    {
        private ServiceHost host;

        public void startService()
        {
            host = new ServiceHost(typeof(ServiceLeGrand.ServiceHome));

            try
            {
                host.Open();
                Console.WriteLine("Service Started");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service won't start : " + ex.Message);
            }
        }

        public void wait()
        {
        }

        public void stopService()
        {
            if (host.State == CommunicationState.Opened | host.State == CommunicationState.Faulted | host.State == CommunicationState.Opening)
            {

                host.Close();
                Console.WriteLine("Service is stopped");
            }
        }
    }
}
