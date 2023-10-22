using DTDExercise.EF;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace DTDExercise.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DateTimeDayTable info)
        {
            DateTime now = DateTime.Now;
            ViewBag.Date = now.ToString("MM/dd/yyyy");
            ViewBag.Time = now.ToString("hh:mm tt");
            ViewBag.DayOfWeek = now.ToString("dddd");

            var db = new DateTimeDBEntities();
            info.date = DateTime.ParseExact(ViewBag.Date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            info.time = ViewBag.Time;
            info.dayOfweak = ViewBag.DayOfWeek;

            db.DateTimeDayTables.Add(info);
            db.SaveChanges();

            return RedirectToAction("ViewTable");
        }

        public ActionResult ViewTable()
        {
            var db = new DateTimeDBEntities();
            var data = db.DateTimeDayTables.ToList();
            return View(data);
        }

    }
}