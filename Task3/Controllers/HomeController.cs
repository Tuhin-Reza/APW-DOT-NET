using System.Linq;
using System.Web.Mvc;
using Task3.EF;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new Entities();
            var data = db.products.ToList();
            return View(data);
        }

        public ActionResult AddChart(product info)
        {

            var db = new Entities();
            var product = db.products.Find(info.product_id);

            if (product != null)
            {
                var chartItem = new addchart
                {
                    user_id = 1,
                    prod_id = product.product_id,
                    prod_name = product.product_name,
                    prod_price = product.price
                };
                db.addcharts.Add(chartItem);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}