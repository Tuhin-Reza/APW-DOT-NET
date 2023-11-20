using System.Linq;
using System.Web.Mvc;
using ZeroHunger.DTOS;
using ZeroHunger.EF;
using ZeroHunger.MAPPER;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        private ZeroHungerDBEntities db;
        private HungryMapper mapper;

        public RestaurantController()
        {
            db = new ZeroHungerDBEntities();
            mapper = new HungryMapper();
        }
        // GET: Restaurant
        public ActionResult Index()
        {

            var resUser = (from u in db.Restaurants
                           where u.userID == sessionUser.id
                           select u).SingleOrDefault();

            if (resUser != null)
            {
                var resUserDTO = mapper.RestaurantToDTO(resUser);
                ViewBag.contactPersonName = resUserDTO.contactPersonName;
                var foodCollectRequest = (from res in db.FoodCollectRequests
                                          where res.retaurantID == resUser.id
                                          orderby res.expiryDate descending
                                          select res).ToList();
                if (foodCollectRequest != null)
                {
                    var foodCollectRequestDTO = mapper.FoodCollectRequestListToDTO(foodCollectRequest);
                    return View(foodCollectRequestDTO);
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult CreateFoodCollectRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFoodCollectRequest(FoodCollectRequestDTO data)
        {
            if (ModelState.IsValid)
            {

                var restID = (from u in db.Restaurants
                              where u.userID == sessionUser.id
                              select u).SingleOrDefault();

                var foodCollectRequestEntity = mapper.DTOToFoodCollectRequest(data);
                foodCollectRequestEntity.statusType = "Request Pending";
                foodCollectRequestEntity.retaurantID = restID.id;

                db.FoodCollectRequests.Add(foodCollectRequestEntity);
                db.SaveChanges();

                var corruentFoodCollectRequestID = (from u in db.FoodCollectRequests
                                                    where u.id == foodCollectRequestEntity.id && u.retaurantID == restID.id
                                                    select u.id).SingleOrDefault();
                var processingEntity = new Processing
                {
                    requestID = corruentFoodCollectRequestID,
                };
                db.Processings.Add(processingEntity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(data);
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