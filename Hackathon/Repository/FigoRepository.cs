using System;
using System.Collections.Generic;
using System.Linq;
using Hackathon.FigoApi.Providers;
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
                new BankModel() {BankId = 1, BankName = "mBank S.A.", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 2, BankName = "Commerzbank", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 4, BankName = "Deutsche Bank", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 5, BankName = "Eurobank", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 6, BankName = "Noble Bank", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 7, BankName = "Idea", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 8, BankName = "BGZ BNP", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 9, BankName = "PKO BP S.A", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 10, BankName = "Millenium", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 11, BankName = "ING", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 12, BankName = "Bank BPH", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 14, BankName = "Citi ", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 15, BankName = "BOS Bank", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 16, BankName = "GET IN BANK", AuthUrl = "/BankWeb/Login?ssourl={url}"},
                new BankModel() {BankId = 18, BankName = "ALIOR", AuthUrl = "/BankWeb/Login?ssourl={url}"},
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

        public static bool IsPossibleSelfPayment(BankToken bankToken, ShopProduct product)
        {
            var figoAccountProvider = new FigoAccountProvider(new FigoSessionProvider());
            var accounts = figoAccountProvider.GetAccounts();

            if (accounts != null && accounts.Any())
            {
                return accounts.ToList().Exists(i => i.Balance.Balance >= (double) product.TotalValue);
            }

            return false;
        }
    }
}