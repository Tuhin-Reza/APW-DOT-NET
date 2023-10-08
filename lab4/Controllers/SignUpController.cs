using lab4.Models;
using System.Web.Mvc;

namespace lab4.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SignUp info)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Signup");
            }
            return View(info);
        }
    }
}