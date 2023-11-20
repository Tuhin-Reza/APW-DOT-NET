using System.Linq;
using System.Web.Mvc;
using ZeroHunger.DTOS;
using ZeroHunger.EF;
using ZeroHunger.MAPPER;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        private ZeroHungerDBEntities db;
        private HungryMapper mapper;
        public HomeController()
        {
            db = new ZeroHungerDBEntities();
            mapper = new HungryMapper();
        }
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
        public ActionResult Signup(RestaurantDTO data)
        {

            if (ModelState.IsValid)
            {
                var data2 = mapper.DTOToRestaurant(data);
                var data3 = mapper.DTOToUserRestaurant(data);

                var roleID = (from role in db.Roles
                              where role.type == "Restaurant"
                              select role.id).SingleOrDefault();

                if (roleID > 0)
                {
                    var newUser = new User
                    {
                        username = data3.username,
                        password = data3.password,
                        roleID = roleID
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    var userID = (from user in db.Users
                                  where user.username == data3.username && user.password == data3.password && user.roleID == roleID
                                  select user.id).SingleOrDefault();
                    if (userID > 0)
                    {
                        var restaurantUser = new Restaurant
                        {
                            restaurantName = data2.restaurantName,
                            location = data2.location,
                            contactPersonName = data2.contactPersonName,
                            contactPersonNumber = data2.contactPersonNumber,
                            contactPersonDesignation = data2.contactPersonDesignation,
                            restaurantType = data2.restaurantType,
                            email = data2.email,
                            userID = userID
                        };
                        db.Restaurants.Add(restaurantUser);
                        db.SaveChanges();
                        return RedirectToAction("Signin");
                    }
                }
            }
            return View(data);
        }



        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(UserDTO data)
        {
            if (ModelState.IsValid)
            {
                var userInput = mapper.DTOToUser(data);
                var userRestaurant = (from u in db.Users
                                      where u.username == userInput.username && u.password == userInput.password
                                      join r in db.Roles on u.roleID equals r.id
                                      where r.type == "Restaurant"
                                      select new
                                      {
                                          user = u,
                                          role = r
                                      }).SingleOrDefault();
                if (userRestaurant == null)
                {
                    var userAdmin = (from u in db.Users
                                     where u.username == userInput.username && u.password == userInput.password
                                     join r in db.Roles on u.roleID equals r.id
                                     where r.type == "Admin"
                                     select new
                                     {
                                         user = u,
                                         role = r
                                     }).SingleOrDefault();
                    if (userAdmin == null)
                    {
                        var userCollector = (from u in db.Users
                                             where u.username == userInput.username && u.password == userInput.password
                                             join r in db.Roles on u.roleID equals r.id
                                             where r.type == "Collector"
                                             select new
                                             {
                                                 user = u,
                                                 role = r
                                             }).SingleOrDefault();
                        if (userCollector == null)
                        {
                            var userDistributor = (from u in db.Users
                                                   where u.username == userInput.username && u.password == userInput.password
                                                   join r in db.Roles on u.roleID equals r.id
                                                   where r.type == "Distributor"
                                                   select new
                                                   {
                                                       user = u,
                                                       role = r
                                                   }).SingleOrDefault();
                            if (userDistributor == null)
                            {
                                ViewBag.signinError = "Provide Correct Information";
                                return View(data);
                            }
                            else
                            {
                                var distributorEntity = (from u in db.Users
                                                         where u.roleID == userDistributor.role.id
                                                         select u).SingleOrDefault();
                                Session["userData"] = mapper.UserToDTO(distributorEntity);
                                return RedirectToAction("Index", "Distributor");
                            }
                        }
                        else
                        {
                            var collectorEntity = (from u in db.Users
                                                   where u.roleID == userCollector.role.id
                                                   select u).SingleOrDefault();
                            Session["userData"] = mapper.UserToDTO(collectorEntity);
                            return RedirectToAction("Index", "Collector");
                        }
                    }
                    else
                    {
                        var adminEntity = (from u in db.Users
                                           where u.roleID == userAdmin.role.id
                                           select u).SingleOrDefault();
                        Session["userData"] = mapper.UserToDTO(adminEntity);
                        return RedirectToAction("Index", "Admin");
                    }
                }
                else
                {
                    var restaurantEntity = (from u in db.Users
                                            where u.username == userRestaurant.user.username && u.password == userRestaurant.user.password && u.roleID == userRestaurant.role.id
                                            select u).SingleOrDefault();
                    Session["userData"] = mapper.UserToDTO(restaurantEntity);
                    return RedirectToAction("Index", "Restaurant");

                }
            }

            return View(data);
        }

    }
}