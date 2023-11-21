using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger.AUTH;
using ZeroHunger.DTOS;
using ZeroHunger.EF;
using ZeroHunger.MAPPER;

namespace ZeroHunger.Controllers
{
    public class CollectorController : Controller
    {
        // GET: Collector
        private ZeroHungerDBEntities db;
        private HungryMapper mapper;
        public CollectorController()
        {
            mapper = new HungryMapper();
            db = new ZeroHungerDBEntities();
        }
        [Logged]
        public ActionResult Index()
        {
            ViewBag.name = sessionUser.username;

            int collectorFindingrequestcount = (from d in db.FoodCollectRequests
                                                where d.statusType == "Collector Finding"
                                                select d).Count();
            ViewBag.collectorFindingrequestcount = collectorFindingrequestcount;

            //------------------------------ Collectect Pending -------------------------------------------------
            var collectorUser = (from c in db.Collectors
                                 where c.userID == sessionUser.id
                                 select c).SingleOrDefault();

            var collectorAcceptRequestList = (from fcrH in db.FoodCollectRequestHistorys
                                              join fcr in db.FoodCollectRequests
                                              on fcrH.requestID equals fcr.id
                                              where fcrH.collectorID == collectorUser.id && fcr.statusType == "Collector Comming Soon"
                                              select fcr).ToList().Count();

            ViewBag.collectorAcceptRequestCount = collectorAcceptRequestList;

            //--------------------------- Collector Finding ------------------------------------
            var foodCollectRequestlist = (from d in db.FoodCollectRequests
                                          where d.statusType == "Collector Finding"
                                          orderby d.expiryDate ascending
                                          select d).ToList();
            var foodCollectRequestDTOlist = mapper.FoodCollectRequestListToDTO(foodCollectRequestlist);
            return View(foodCollectRequestDTOlist);
        }



        public ActionResult detailsFoodRequest(int restaurant_id, int fcr_id)
        {
            var data = db.Restaurants.Find(restaurant_id);
            var restFCR = mapper.RestaurantFoodCollectRequestToDTO(data, fcr_id);
            return View(restFCR);
        }


        public ActionResult acceptRequest(int id)
        {
            if (id != 0)
            {
                var foodCollectRequest = (from d in db.FoodCollectRequests
                                          where d.id == id
                                          select d).SingleOrDefault();
                var collectorUser = (from c in db.Collectors
                                     where c.userID == sessionUser.id
                                     select c).SingleOrDefault();
                if (collectorUser != null)
                {
                    var fcrH = (from history in db.FoodCollectRequestHistorys
                                where history.requestID == id
                                select history).SingleOrDefault();
                    if (fcrH != null)
                    {
                        fcrH.collectorID = collectorUser.id;
                        db.SaveChanges();

                        foodCollectRequest.statusType = "Collector Comming Soon";
                        db.SaveChanges();
                    }

                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult collectPending()
        {
            var collectorUser = (from c in db.Collectors
                                 where c.userID == sessionUser.id
                                 select c).SingleOrDefault();

            var collectorAcceptRequestList = (from fcrH in db.FoodCollectRequestHistorys
                                              join fcr in db.FoodCollectRequests
                                              on fcrH.restaurantID equals fcr.retaurantID
                                              where fcrH.collectorID == collectorUser.id && fcr.statusType == "Collector Comming Soon"
                                              select fcr).ToList();

            List<Restaurant> restaurantList = new List<Restaurant>();
            foreach (var item in collectorAcceptRequestList)
            {
                var restaurantId = item.retaurantID;
                bool isAlreadyAdded = false;
                foreach (var existingRestaurant in restaurantList)
                {
                    if (existingRestaurant.id == restaurantId)
                    {
                        isAlreadyAdded = true;
                        break;
                    }
                }
                if (!isAlreadyAdded)
                {
                    var restaurant = (from rest in db.Restaurants
                                      where rest.id == restaurantId
                                      select rest).SingleOrDefault();

                    if (restaurant != null)
                    {
                        restaurantList.Add(restaurant);
                    }
                }
            }
            var restFCR = mapper.RestaurantFoodCollectRequestCollectorListDTO(restaurantList);
            return View(restFCR);
        }


        public ActionResult collectedFood(int id)
        {
            if (id != 0)
            {
                var collectorUser = (from c in db.Collectors
                                     where c.userID == sessionUser.id
                                     select c).SingleOrDefault();

                var foodCollectRequest = (from d in db.FoodCollectRequests
                                          where d.id == id
                                          select d).SingleOrDefault();
                if (collectorUser != null && foodCollectRequest != null)
                {
                    var createHistory = new CollectorHistory()
                    {
                        collectDate = DateTime.Now.Date,
                        collectTime = DateTime.Now,
                        pickUpLocation = foodCollectRequest.pickUpLocation,
                        TransportationMethod = collectorUser.vehicleType,
                        requestID = foodCollectRequest.id,
                        collectorID = collectorUser.id

                    };
                    db.CollectorHistorys.Add(createHistory);
                    db.SaveChanges();

                    foodCollectRequest.statusType = "Food Collected";
                    db.SaveChanges();

                    var procesingData = new Processing()
                    {
                        requestID = foodCollectRequest.id,
                        collectorID = collectorUser.id,
                    };
                    db.Processings.Add(procesingData);
                    db.SaveChanges();
                }

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