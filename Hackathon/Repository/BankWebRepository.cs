using Hackathon.Repository.BankWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Repository
{
    public static class BankWebRepository
    {
        private static List<User> _users = new List<User>()
        {
            new User()
            {
                UserName = "slawomir.brys",
                Password = "password"
            },
            new User()
            {
                UserName = "tomasz.galus",
                Password = "password"
            },
            new User()
            {
                UserName = "mikolaj.skoczylas",
                Password = "password"
            }
        };

        
        public static List<User> Users { get; set; }
    }
}