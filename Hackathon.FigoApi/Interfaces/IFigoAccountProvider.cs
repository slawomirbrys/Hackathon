using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using figo;

namespace Hackathon.FigoApi.Interfaces
{
    public interface IFigoAccountProvider
    {
        IEnumerable<FigoAccount> GetAccounts();
    }
}
