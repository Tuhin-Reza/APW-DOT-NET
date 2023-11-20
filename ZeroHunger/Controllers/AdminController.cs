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

            int collectedcount = (from d in db.FoodCollectRequests
                                  where d.statusType == "Food Collected"
                                  select d).Count();
            ViewBag.collectedcount = collectedcount;



            var foodCollectRequestlist = (from d in db.FoodCollectRequests
                                          where d.statusType != "Date Expired" && d.statusType != "Completed" && d.statusType != "Cancel"
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
                        collectDate = DateTime.Today,
                        collectTime = DateTime.Now,
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

            }
            return View();
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

            }
            return View();
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