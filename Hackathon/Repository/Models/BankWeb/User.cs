using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Repository.Models.BankWeb
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public List<Account> Accounts { get; set; }
        public bool IsFigoAllowed { get; set; }
    }
}