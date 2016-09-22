using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using figo;

namespace Hackathon.FigoConsole
{
    class Program
    {
        static void WaitTask(Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    // Handle only WebException
                    if (e is WebException)
                    {
                        Console.WriteLine("Message: {0}\nSource: {1}\nStackTrace: {2}", e.Message, e.Source, e.StackTrace);
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var validCertificates = new string[]
            {
                "38AE4A326F16EA1581338BB0D8E4A635E727F107",
                "DBE2E9158FC9903084FE36CAA61138D85A205D93"
            };
            FigoSession session = new FigoSession
            {
                AccessToken = "ASHWLIkouP2O6_bgA2wWReRhletgWKHYjLqDaqb0LFfamim9RjexTo22ujRIP_cjLiRiSyQXyt2kM1eXU2XLFZQ0Hro15HikJQT_eNeT_9XQ",
                // the same as default one here, but can be modified for testing purposes
                ApiEndpoint = "https://api.figo.me",
                OnRequestInitialize = (request) =>
                {
                    // figo.net is portable, not all of the platforms have a support for ServerCertificateValidationCallback
                    // that's why check certificate on the client side 
                    request.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => {
                        X509Certificate x509Certificate = cert;
                        return validCertificates.Contains(x509Certificate.GetCertHashString());
                    };
                }
            };
            // print out a list of accounts including its balance
            var taskAccounts = session.GetAccounts();
            WaitTask(taskAccounts);
            foreach (FigoAccount account in taskAccounts.Result)
            {
                Console.WriteLine(account.Name);

                var taskBalance = session.GetAccountBalance(account);
                WaitTask(taskBalance);
                Console.WriteLine(taskBalance.Result.Balance);
            }

            // print out the list of all transactions on a specific account
            var taskTransactions = session.GetTransactions("A1.2");
            WaitTask(taskTransactions);
            foreach (FigoTransaction transaction in taskTransactions.Result)
            {
                Console.WriteLine(transaction.Purpose);
            }

            Console.ReadKey();
        }
    }
}
