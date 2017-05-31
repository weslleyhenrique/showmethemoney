using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapSite2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title="My Consulting";
            return View();
        }

        public ActionResult TestYourPage()
        {
            return View();
        }

    }
}