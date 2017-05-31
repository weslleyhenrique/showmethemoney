using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapSite2.Controllers
{

    [RoutePrefix("midiasocial")]
    public class TesteMidiaController : Controller
    {
        [Route("faca-o-teste")]
        public ActionResult Test()
        {
            return View();
        }
    }
}