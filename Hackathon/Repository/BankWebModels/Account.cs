using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Repository.BankWebModels
{
    public class Account
    {
        public string Nrb { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> History { get; set; }
    }
}