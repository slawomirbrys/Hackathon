using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using figo;
using Hackathon.FigoApi.Interfaces;

namespace Hackathon.FigoApi.Providers
{
    public class FigoAccountProvider : IFigoAccountProvider
    {
        private readonly IFigoSessionProvider _figoSessionProvider;

        public FigoAccountProvider(IFigoSessionProvider figoSessionProvider)
        {
            _figoSessionProvider = figoSessionProvider;
        }

        public IEnumerable<FigoAccount> GetAccounts()
        {
            var session = _figoSessionProvider.GetFigoSession();
            var taskAccounts = _figoSessionProvider.GetFigoSession().GetAccounts();

            WaitTask(taskAccounts);

            foreach (var account in taskAccounts.Result)
            {
                var taskBalance = session.GetAccountBalance(account);

                WaitTask(taskBalance);
            }

            return taskAccounts.Result;
        }

        private static void WaitTask(Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
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
    }
}
