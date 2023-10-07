using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Registration regis)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Login");
            }
            return View(regis);

        }
        public ActionResult Login()
        {   
            return View();
        }

    }
}