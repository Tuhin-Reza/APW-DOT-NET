using System;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger.AUTH;
using ZeroHunger.DTOS;
using ZeroHunger.EF;
using ZeroHunger.MAPPER;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        private ZeroHungerDBEntities db;
        private HungryMapper mapper;
        public AdminController()
        {
            mapper = new HungryMapper();
            db = new ZeroHungerDBEntities();
        }
        // GET: Admin
        [Logged]
        public ActionResult Index()
        {
            ViewBag.name = sessionUser.username;

            int requestcount = (from d in db.FoodCollectRequests
                                where d.statusType == "Request Pending"
                                select d).Count();
            ViewBag.requestCount = requestcount;

            var collectedcount = (from d in db.FoodCollectRequests
                                  where d.statusType == "Food Collected"
                                  select d).Count();
            ViewBag.collectedcount = collectedcount;



            var foodCollectRequestlist = (from d in db.FoodCollectRequests
                                          where d.statusType == "Request Pending"
                                          orderby d.expiryDate ascending
                                          select d).ToList();
            var foodCollectRequestDTOlist = mapper.FoodCollectRequestListToDTO(foodCollectRequestlist);
            return View(foodCollectRequestDTOlist);
        }


        public ActionResult requestDecission()
        {
            var data = db.Restaurants.ToList();
            var restFCR = mapper.RestaurantFoodCollectRequestListDTO(data);
            return View(restFCR);
        }


        public ActionResult requestSpecificDecission(int restaurant_id, int fcr_id)
        {
            var data = db.Restaurants.Find(restaurant_id);
            var restFCR = mapper.RestaurantFoodCollectRequestToDTO(data, fcr_id);
            return View(restFCR);
        }


        public ActionResult requestAccept(int id)
        {
            if (id != 0)
            {
                var foodCollectRequest = (from d in db.FoodCollectRequests
                                          where d.id == id
                                          select d).SingleOrDefault();
                if (foodCollectRequest.expiryDate >= DateTime.Today)
                {
                    foodCollectRequest.statusType = "Collector Finding";
                    db.SaveChanges();

                    var fcrH = new FoodCollectRequestHistory()
                    {
                        requestStatus = "Accept",
                        collectReason = "Hungry",
                        requestID = foodCollectRequest.id,
                        restaurantID = foodCollectRequest.retaurantID,

                    };
                    db.FoodCollectRequestHistorys.Add(fcrH);
                    db.SaveChanges();
                }
                else
                {
                    foodCollectRequest.statusType = "Date Expired";
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult requestCancel(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult requestCancel(ReasonDTO data)
        {
            if (ModelState.IsValid)
            {
                var foodCollectRequest = (from d in db.FoodCollectRequests
                                          where d.id == data.id
                                          select d).SingleOrDefault();

                if (foodCollectRequest.expiryDate < DateTime.Today)
                {
                    foodCollectRequest.statusType = "Date Expired";
                    db.SaveChanges();
                }
                else
                {
                    foodCollectRequest.statusType = "Cancel";
                    db.SaveChanges();

                    var fcrH = new FoodCollectRequestHistory()
                    {
                        requestStatus = "Cancel",
                        collectReason = data.reason,
                        collectDate = DateTime.Today,
                        collectTime = DateTime.Now,
                        requestID = foodCollectRequest.id,
                        restaurantID = foodCollectRequest.retaurantID,

                    };
                    db.FoodCollectRequestHistorys.Add(fcrH);
                    db.SaveChanges();

                }

            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult assignCollector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult assignCollector(CollectorDTO data)
        {
            if (ModelState.IsValid)
            {
                var collectorUser = mapper.DTOToCollectorUser(data);
                var collRoleID = (from role in db.Roles
                                  where role.type == "Collector"
                                  select role.id).SingleOrDefault();
                if (collRoleID != 0)
                {
                    var check = (from user in db.Users
                                 where user.username == data.username && user.password == data.password
                                 select user).SingleOrDefault();
                    if (check == null)
                    {
                        collectorUser.roleID = collRoleID;
                        db.Users.Add(collectorUser);
                        db.SaveChanges();

                        var userid = (from user in db.Users
                                      where user.username == collectorUser.username && user.password == collectorUser.password
                                      select user.id).SingleOrDefault();

                        var collectorData = mapper.DTOToCollector(data);
                        collectorData.userID = userid;
                        db.Collectors.Add(collectorData);
                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["collectorExists"] = "Provide Unique Username & Password";
                        return View(data);
                    }
                }
            }
            return View(data);
        }


        [HttpGet]
        public ActionResult assignDistributor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult assignDistributor(DistributorDTO data)
        {
            if (ModelState.IsValid)
            {
                var distributorUser = mapper.DTOToDistributorUser(data);
                var distRoleID = (from role in db.Roles
                                  where role.type == "Distributor"
                                  select role.id).SingleOrDefault();
                if (distRoleID != 0)
                {
                    var check = (from user in db.Users
                                 where user.username == distributorUser.username && user.password == distributorUser.password
                                 select user).SingleOrDefault();
                    if (check == null)
                    {
                        distributorUser.roleID = distRoleID;
                        db.Users.Add(distributorUser);
                        db.SaveChanges();

                        var userId = (from user in db.Users
                                      where user.username == distributorUser.username && user.password == distributorUser.password
                                      select user.id).SingleOrDefault();

                        var distributorData = mapper.DTOToDistributor(data);
                        distributorData.userID = userId;
                        db.Distributors.Add(distributorData);
                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["DistributorExists"] = "Provide Unique Username & Password";
                        return View(data);
                    }
                }
            }
            return View(data);
        }

        public ActionResult assignArea()
        {
            var fcr = (from d in db.FoodCollectRequests
                       where d.statusType == "Food Collected"
                       select d).ToList();
            var fcrDTO = mapper.FoodCollectRequestListToDTO(fcr);
            return View(fcrDTO);
        }

        [HttpPost]
        public ActionResult assignArea(assignAreaDTO data)
        {
            if (ModelState.IsValid)
            {
                if (data.id != 0)
                {
                    var processingData = (from p in db.Processings
                                          where p.requestID == data.id
                                          select p).SingleOrDefault();

                    processingData.area = data.area;
                    db.SaveChanges();

                    var foodCollectRequest = (from d in db.FoodCollectRequests
                                              where d.id == data.id
                                              select d).SingleOrDefault();
                    foodCollectRequest.statusType = "Distributor Finding";
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var fcr = (from d in db.FoodCollectRequests
                           where d.statusType == "Food Collected"
                           select d).ToList();
                var fcrDTO = mapper.FoodCollectRequestListToDTO(fcr);
                return View(fcrDTO);
            }

            return RedirectToAction("Index");
        }



        private UserDTO sessionUser
        {
            get
            {
                return Session["UserData"] as UserDTO;
            }
        }
    }
}