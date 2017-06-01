using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapSite2.Controllers
{
    [RoutePrefix("midiasocial")]
    public class MidiaController : Controller
    {
        // GET: Midia
        [Route("faca-o-teste")]

        public ActionResult teste()
        {
            return View();
        }

        // GET: Midia
        [Route("thank-you")]

        public ActionResult agradecimento()
        {
            return View();
        }
    }
}