using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackathon.FigoApi.Providers;

namespace Hackathon.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var figoAccountProvider = new FigoAccountProvider(new FigoSessionProvider());
            var accounts = figoAccountProvider.GetAccounts();

            System.Console.ReadKey();
        }
    }
}
