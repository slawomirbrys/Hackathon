using Hackathon.Repository.Models.BankWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Repository
{
    public class BankWebRepository
    {
        private static BankWebRepository _instance = new BankWebRepository();
        private List<User> _users = null;


        public static BankWebRepository Instance
        {
            get
            {
                _instance.Login("slawomir.brys", "password");
                return _instance;
            }
        }

        public User LoggedUser { get; set; }


        public BankWebRepository()
        {
            _users = new List<User>();
            _users.Add(new User()
            {
                Login = "slawomir.brys",
                Password = "password",
                FirstName = "Sławomir",
                LastName = "Bryś",
                Email = "slawomir.brys@bank.io",
                Address1 = "Coolest Street 21",
                Address2 = "02-777",
                City = "Warsaw",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        Nrb = "PL371140926376031880416168827314",
                        Name = "Current account",
                        Balance = 1500,
                        History = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                NrbFrom = "PL371140926376031880416168827314",
                                NrbTo = "PL471140976857058922014252714588",
                                Date = "2016-09-22",
                                Title = "Invoice for my new phone",
                                TransferType = TransferType.Outgoing,
                                Amount = 2000
                            },
                            new Transaction()
                            {
                                NrbFrom = "PL371140926376031880416168827314",
                                NrbTo = "PL861140637662928947923726514464",
                                Date = "2016-09-14",
                                Title = "Online shop payment",
                                TransferType = TransferType.Outgoing,
                                Amount = 750
                            },
                            new Transaction()
                            {
                                NrbFrom = "PL371140926376031880416168827314",
                                NrbTo = "PL861140637662928947923726514464",
                                Date = "2016-09-13",
                                Title = "Online shop payment",
                                TransferType = TransferType.Outgoing,
                                Amount = 750
                            },
                            new Transaction()
                            {
                                NrbFrom = "PL681140192224161184691122740935",
                                NrbTo = "PL371140926376031880416168827314",
                                Date = "2016-09-10",
                                Title = "Return for a dinner",
                                TransferType = TransferType.Incoming,
                                Amount = 178.13m
                            }
                        }
                    },
                    new Account()
                    {
                        Nrb = "PL251140746167296292301159271465",
                        Name = "Salary account",
                        Balance = 21.21m,
                        History = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                NrbFrom = "PL611140715583176442686061542445",
                                NrbTo = "PL251140746167296292301159271465",
                                Date = "2016-09-10",
                                Title = "Payroll for 2016-09",
                                TransferType = TransferType.Incoming,
                                Amount = 21.21m
                            }
                        }
                    },
                    new Account()
                    {
                        Nrb = "PL721140014333465284278667875408",
                        Name = "Saving account",
                        Balance = 50000,
                        History = new List<Transaction>()
                    }
                }
            });
            _users.Add(new User()
            {
                Login = "tomasz.galus",
                Password = "password",
                FirstName = "Tomasz",
                LastName = "Galus",
                Email = "tomasz.galus@happy.io",
                Address1 = "Happiest Street 7",
                Address2 = "00-200",
                City = "Warsaw",
                Accounts = new List<Account>()
            });
            _users.Add(new User()
            {
                Login = "mikolaj.skoczylas",
                Password = "password",
                FirstName = "Mikołaj",
                LastName = "Skoczylas",
                Email = "mikolaj.skoczylas@funny.io",
                Address1 = "Funniest Street 13",
                Address2 = "00213",
                City = "New York",
                Accounts = new List<Account>()
            });

        }

        public User Login(string login, string password)
        {
            var user = _users.FirstOrDefault(_ => _.Login == login && _.Password == password);
            _instance.LoggedUser = user;
            return user;
        }

        public void Logout()
        {
            this.LoggedUser = null;
        }
    }
}