﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Repository.BankWebModels
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public string Email { get; set; }

    }
}