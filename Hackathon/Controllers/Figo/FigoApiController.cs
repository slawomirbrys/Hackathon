using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Hackathon.Repository;
using Hackathon.Repository.FigoModels;
using Hackathon.Repository.FinancialProductsModels;
using Hackathon.Repository.Models.Figo;
using Hackathon.Repository.Models.FinancialProducts;

namespace Hackathon.Controllers.Figo
{
    public class FigoApiController : ApiController
    {
        public IEnumerable<BankModel> GetAvailableBanks(BankToken bankToken)
        {
            return FigoRepository.GetAvailableBanks(bankToken);
        }

        public IEnumerable<LoanOffer> GetFinancialOffers(BankToken bankToken, IEnumerable<ShopProduct> shopProducts)
        {
            return FigoRepository.GetFinancialOffers(bankToken, shopProducts);
        }

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}
    }
}