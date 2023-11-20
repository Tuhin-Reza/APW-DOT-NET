using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZeroHunger.Controllers
{
    public class CollectorController : Controller
    {
        // GET: Collector
        public ActionResult Index()
        {
            return View();
        }
    }
}