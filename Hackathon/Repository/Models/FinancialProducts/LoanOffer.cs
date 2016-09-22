using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Repository.FinancialProductsModels
{
    public class LoanOffer
    {
        public int BankId { get; set; }
        public decimal CreditAmout { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalCostOfCredit { get; set; }
        public string Currency { get; set; }
    }
}