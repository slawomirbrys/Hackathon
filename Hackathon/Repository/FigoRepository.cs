using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon.Repository.FigoModels;
using Hackathon.Repository.FinancialProductsModels;
using Hackathon.Repository.Models.Figo;
using Hackathon.Repository.Models.FinancialProducts;

namespace Hackathon.Repository
{
    public class FigoRepository
    {
        public static IEnumerable<BankModel> GetAvailableBanks(BankToken bankToken)
        {
            return new List<BankModel>()
            {
                new BankModel() {BankId = 1, BankName = "mBank S.A."},
                new BankModel() {BankId = 2, BankName = "Commerzbank"},
                new BankModel() {BankId = 4, BankName = "PKO BP S.A"},
                new BankModel() {BankId = 3, BankName = "Deutsche Bank"},
            };
        }

        public static IEnumerable<LoanOffer> GetFinancialOffers(BankToken bankToken, IEnumerable<ShopProduct> products)
        {
            return new List<LoanOffer>()
            {
                new LoanOffer() {BankId = 1, Currency = "EUR", CreditAmout = 1200, InterestRate = 2, PeriodFrom = DateTime.Now, PeriodTo = DateTime.Now.AddDays(365)},
                new LoanOffer() {BankId = 2, Currency = "EUR", CreditAmout = 1200, InterestRate = 3, PeriodFrom = DateTime.Now, PeriodTo = DateTime.Now.AddDays(365)},
                new LoanOffer() {BankId = 3, Currency = "EUR", CreditAmout = 1200, InterestRate = 1, PeriodFrom = DateTime.Now, PeriodTo = DateTime.Now.AddDays(365)},
                new LoanOffer() {BankId = 4, Currency = "EUR", CreditAmout = 1200, InterestRate = 5, PeriodFrom = DateTime.Now, PeriodTo = DateTime.Now.AddDays(365)},
            };
        }

        public static IEnumerable<LoanOffer> GetFinancialOffers(BankToken bankToken, ShopProduct product)
        {
            return new List<LoanOffer>()
            {
                new LoanOffer() {BankId = 1, Currency = "EUR", CreditAmout = 1200, InterestRate = 2, PeriodFrom = DateTime.Now, PeriodTo = DateTime.Now.AddDays(365)},
                new LoanOffer() {BankId = 2, Currency = "EUR", CreditAmout = 1200, InterestRate = 3, PeriodFrom = DateTime.Now, PeriodTo = DateTime.Now.AddDays(365)},
                new LoanOffer() {BankId = 3, Currency = "EUR", CreditAmout = 1200, InterestRate = 1, PeriodFrom = DateTime.Now, PeriodTo = DateTime.Now.AddDays(365)},
                new LoanOffer() {BankId = 4, Currency = "EUR", CreditAmout = 1200, InterestRate = 5, PeriodFrom = DateTime.Now, PeriodTo = DateTime.Now.AddDays(365)},
            };
        }
    }
}