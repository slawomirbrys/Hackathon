using Hackathon.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon.Controllers
{
    public class BankWebController : Controller
    {
        // GET: BankWeb
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            BankWebRepository.Instance.Logout();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            var user = BankWebRepository.Instance.Login(login, password);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            if (base.Request.QueryString.AllKeys.Contains("ssourl"))
            {
                string url = base.Request.QueryString["ssourl"];
                url += "?token=" + Guid.NewGuid();
                return Redirect(url);
            }

            return RedirectToAction("Accounts");
        }


        public ActionResult Accounts()
        {
            if (BankWebRepository.Instance.LoggedUser == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }


        public ActionResult AccountHistory(string id)
        {
            var history = BankWebRepository.Instance.LoggedUser.Accounts
                .Where(w => w.Nrb == id)
                .FirstOrDefault()
                ?.History;
            return View(history);
        }


        public ActionResult Personal()
        {
            var user = BankWebRepository.Instance.LoggedUser;
            return View(user);
        }
    }
}