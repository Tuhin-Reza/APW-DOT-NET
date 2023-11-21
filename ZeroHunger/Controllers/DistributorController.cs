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

            var distData = db.FoodCollectRequests.ToList();

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