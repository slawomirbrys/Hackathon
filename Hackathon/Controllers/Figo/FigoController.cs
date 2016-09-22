using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon.Controllers
{
    public class FigoController : Controller
    {
        // GET: Figo
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AuthCompleted()
        {
            return base.Redirect("~/Shop?logged");
        }
    }
}