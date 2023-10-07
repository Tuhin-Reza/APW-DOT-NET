using Lab3.Models;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form(Form info)
        {
            return View(info);
        }

        //public ActionResult Form(FormCollection fc)
        //{
        //    ViewBag.name = fc["name"];
        //    ViewBag.userid = fc["userid"];
        //    ViewBag.gender = fc["gender"];
        //    ViewBag.profession = fc["profession"];
        //    ViewBag.hobbies = fc["hobbies"];
        //    return View();
        //}
    }
}