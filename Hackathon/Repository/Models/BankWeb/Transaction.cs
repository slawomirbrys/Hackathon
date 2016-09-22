using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Repository.Models.BankWeb
{
    public class Transaction
    {
        public string IbanFrom { get; set; }
        public string IbanTo { get; set; }
        public TransferType TransferType { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
    }
}