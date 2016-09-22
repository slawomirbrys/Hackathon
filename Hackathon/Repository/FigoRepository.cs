using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon.Repository.FigoModels;

namespace Hackathon.Repository
{
    public class FigoRepository
    {
        IEnumerable<BankModel> GetAvailableBanks(BankToken bankToken)
        {
            return new List<BankModel>()
            {
                new BankModel(),
                new BankModel(),
                new BankModel(),
                new BankModel()
            };
        }
    }
}