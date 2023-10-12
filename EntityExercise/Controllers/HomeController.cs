using EntityExercise.EF;
using System.Linq;
using System.Web.Mvc;

namespace EntityExercise.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult ViewCourse()
        {
            var db = new Entities();
            var data = db.courses.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(cours info)
        {
            var db = new Entities();
            db.courses.Add(info);
            db.SaveChanges();
            return RedirectToAction("ViewCourse");
        }


        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var db = new Entities();
            var data = (from data2 in db.courses
                        where data2.id == id
                        select data2).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditCourse(cours info)
        {
            var db = new Entities();
            var exdata = db.courses.Find(info.id);
            exdata.c_name = info.c_name;
            //db.Entry(exdata).CurrentValues.SetValues(info);
            exdata.c_name = info.c_name;
            db.SaveChanges();
            return RedirectToAction("ViewCourse");
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var db = new Entities();
            var data = db.courses.Find(id);
            db.courses.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ViewCourse");
        }


        [HttpPost]
        public ActionResult SearchCourse(string search)
        {
            var db = new Entities();
            var data = (from data2 in db.courses
                        where data2.c_name == search
                        select data2).ToList();
            //var data = db.courses.ToList();
            //var data = db.courses.Where(c => c.c_name == search).ToList();

            return View(data);
        }


    }
}