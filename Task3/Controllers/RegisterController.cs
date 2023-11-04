using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using Task3.DTOS;
using Task3.EF;

namespace Task3.Controllers
{
    public class RegisterController : Controller
    {

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserDTO info)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserDTO, User>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<User>(info);
                var db = new Task3DBEntities();
                db.Users.Add(data);
                db.SaveChanges();
                return RedirectToAction("Signin");
            }
            return View(info);
        }

        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(SigninDTO info)
        {
            var db = new Task3DBEntities();
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.name == info.name && u.password == info.password
                            select u).SingleOrDefault();
                if (user != null)
                {
                    // Model class object is stored in Session object
                    Session["userData"] = user;
                    return RedirectToAction("ProductView", "Home");
                }
                else
                {
                    TempData["user"] = "Incorrect usename & password";
                }

            }
            return View();
        }

    }
}