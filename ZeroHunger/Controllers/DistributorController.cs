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
    public class DistributorController : Controller
    {
        private ZeroHungerDBEntities db;
        private HungryMapper mapper;

        public DistributorController()
        {
            mapper = new HungryMapper();
            db = new ZeroHungerDBEntities();
        }
        // GET: Distributor

        [Logged]
        public ActionResult Index()
        {
            var dist = (from d in db.Distributors
                        where d.userID == sessionUser.id
                        select d).SingleOrDefault();
            ViewBag.DistName = dist.name;
            //-----------------------For waiting Food Collection---------------------------------
            var countTransit = (from cT in db.FoodCollectRequests
                                where cT.statusType == "In Transit"
                                join processing in db.Processings on cT.id equals processing.requestID
                                where processing.distributorID == dist.id
                                select cT).Count();
            ViewBag.CountTransit = countTransit;
            //-----------------------Distribution Processing---------------------------------
            var countProcessing = (from cT in db.FoodCollectRequests
                                   where cT.statusType == "Distribution Processing"
                                   join processing in db.Processings on cT.id equals processing.requestID
                                   where processing.distributorID == dist.id
                                   select cT).Count();
            ViewBag.countProcessing = countProcessing;

            //-----------------------For index list---------------------------------
            var fcr = (from f in db.FoodCollectRequests
                       where f.statusType == "Distributor Finding"
                       select f).ToList();
            var fcrDTO = mapper.FoodCollectRequestProcessingListDTO(fcr);
            return View(fcrDTO);
        }

        [Logged]
        public ActionResult distributionrequestaccept(int id)
        {
            if (id != 0)
            {
                var distID = (from d in db.Distributors
                              where d.userID == sessionUser.id
                              select d.id).SingleOrDefault();

                var processing = (from p in db.Processings
                                  where p.requestID == id
                                  select p).SingleOrDefault();
                processing.distributorID = distID;
                db.SaveChanges();

                var foodCollectRequest = (from d in db.FoodCollectRequests
                                          where d.id == id
                                          select d).SingleOrDefault();
                foodCollectRequest.statusType = "In Transit";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("error");
        }

        [Logged]
        public ActionResult receivedFood()
        {
            var dist = (from d in db.Distributors
                        where d.userID == sessionUser.id
                        select d).SingleOrDefault();

            var processing = (from p in db.Processings
                              where p.distributorID == dist.id
                              select p).ToList();

            var fcr = (from fr in db.FoodCollectRequests
                       where fr.statusType == "In Transit"
                       select fr).ToList();

            var filteredFcr = new List<FoodCollectRequest>();

            foreach (var request in fcr)
            {
                foreach (var process in processing)
                {
                    if (request.id == process.requestID)
                    {
                        filteredFcr.Add(request);
                        break;
                    }
                }
            }
            var fcrDTO = mapper.FoodCollectRequestProcessingListDTO(filteredFcr);
            return View(fcrDTO);

        }

        [Logged]
        public ActionResult collectFood(int id)
        {
            if (id != 0)
            {
                var distID = (from d in db.Distributors
                              where d.userID == sessionUser.id
                              select d.id).SingleOrDefault();

                var collectorHistory = (from c in db.CollectorHistorys
                                        where c.requestID == id
                                        select c).SingleOrDefault();
                collectorHistory.handoverDate = DateTime.Today;
                collectorHistory.handoverTime = DateTime.Now;
                collectorHistory.distributorID = distID;
                db.SaveChanges();

                var processingArea = (from p in db.Processings
                                      where p.requestID == id && p.distributorID == distID
                                      select p.area).SingleOrDefault();
                var distributorHistory = new DistributorHistory()
                {
                    collectDate = DateTime.Today,
                    collectTime = DateTime.Now,
                    distributeLocation = processingArea,
                    requestID = id,
                    collectorID = collectorHistory.collectorID,
                    distributorID = distID

                };
                db.DistributorHistorys.Add(distributorHistory);
                db.SaveChanges();

                var foodCollectRequest = (from d in db.FoodCollectRequests
                                          where d.id == id
                                          select d).SingleOrDefault();
                foodCollectRequest.statusType = "Distribution Processing";
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return RedirectToAction("error");
        }


        [Logged]
        public ActionResult distribute()
        {
            var dist = (from d in db.Distributors
                        where d.userID == sessionUser.id
                        select d).SingleOrDefault();

            var processing = (from p in db.Processings
                              where p.distributorID == dist.id
                              select p).ToList();

            var fcr = (from fr in db.FoodCollectRequests
                       where fr.statusType == "Distribution Processing"
                       select fr).ToList();

            var filteredFcr = new List<FoodCollectRequest>();

            foreach (var request in fcr)
            {
                foreach (var process in processing)
                {
                    if (request.id == process.requestID)
                    {
                        filteredFcr.Add(request);
                        break;
                    }
                }
            }
            var fcrDTO = mapper.FoodCollectRequestProcessingListDTO(filteredFcr);
            return View(fcrDTO);

        }

        [HttpGet]
        [Logged]
        public ActionResult distributecomplete(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        [Logged]
        public ActionResult distributecomplete(DistributionCompleteDTO data)
        {
            if (ModelState.IsValid)
            {
                if (data.id != 0)
                {
                    var distributorHistory = (from dh in db.DistributorHistorys
                                              where dh.requestID == data.id
                                              select dh).SingleOrDefault();
                    distributorHistory.distributeStatus = "Accept";
                    distributorHistory.distributereason = "Hungry";
                    distributorHistory.distributeDate = DateTime.Today;
                    distributorHistory.distributTime = DateTime.Now;
                    distributorHistory.receiverType = data.receiverType;
                    distributorHistory.numberofReceiver = data.numberofReceiver;
                    db.SaveChanges();

                    var fcr = (from f in db.FoodCollectRequests
                               where f.id == data.id
                               select f).SingleOrDefault();
                    fcr.statusType = "Distributed";
                    db.SaveChanges();

                    return RedirectToAction("distribute");
                }
                else
                {
                    return RedirectToAction("error");
                }
            }
            return View(data);
        }



        [HttpGet]
        [Logged]
        public ActionResult distributionCancel(int id)
        {
            TempData["id"] = id;
            return View();
        }

        [HttpPost]
        [Logged]
        public ActionResult distributionCancel(DistributionCancelDTO data)
        {
            TempData["id"] = data.id;
            int id = (int)TempData["id"];

            if (ModelState.IsValid)
            {
                if (data.id != 0)
                {
                    var distributorHistory = (from dh in db.DistributorHistorys
                                              where dh.requestID == id
                                              select dh).SingleOrDefault();
                    distributorHistory.distributeStatus = "Cancel";
                    distributorHistory.distributereason = data.distributereason;
                    distributorHistory.distributeDate = DateTime.Today;
                    distributorHistory.distributTime = DateTime.Now;
                    distributorHistory.receiverType = "None";
                    distributorHistory.numberofReceiver = 0;
                    db.SaveChanges();

                    var fcr = (from f in db.FoodCollectRequests
                               where f.id == id
                               select f).SingleOrDefault();
                    fcr.statusType = "Cancel";
                    db.SaveChanges();

                    return RedirectToAction("distribute");
                }
                else
                {
                    return RedirectToAction("error");
                }
            }
            return View(data);
        }


        [Logged]
        public ActionResult error() { return View(); }

        private UserDTO sessionUser
        {
            get
            {
                return Session["UserData"] as UserDTO;
            }
        }
    }
}