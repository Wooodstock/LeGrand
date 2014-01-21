using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWebNetWinForm
{
    static class Program
    {
        static void Main()
        {
            ServiceServer service = new ServiceServer();
            service.startService();
            Console.ReadKey();
        }
    }
}
