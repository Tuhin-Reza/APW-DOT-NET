using System;
using System.Linq;
using System.Web.Mvc;
using Task3.EF;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        private int userId;
        private Task3DBEntities db;
        //This line declares a private field named db of type Task3DBEntities.
        //This field will be used to store an instance of the Task3DBEntities class, 
        //which represents your database context.
        public HomeController()
        {
            userId = 1101;
            db = new Task3DBEntities();
        }
        //In the constructor of your HomeController is initializing a field named 
        //db with a new instance of the Task3DBEntities class, which represents
        //my Entity Framework database context.

        public ActionResult ProductView()
        {
            var data = db.Products.ToList();
            return View(data);
        }


        public ActionResult AddChart(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("ProductView");
            }

            var existingCartItem = db.AddCharts.SingleOrDefault(item => item.product_id == id);
            if (existingCartItem != null)
            {

                existingCartItem.product_quentity++;
                existingCartItem.total_price = existingCartItem.product_price * existingCartItem.product_quentity;
                db.SaveChanges();
                return RedirectToAction("ProductView");
            }
            else
            {
                var cartItem = new AddChart
                {
                    product_id = product.id,
                    product_name = product.name,
                    product_price = product.price,
                    product_quentity = 1,
                    total_price = product.price,
                    user_id = userId,
                };
                db.AddCharts.Add(cartItem);
                db.SaveChanges();
            }
            return RedirectToAction("ProductView");
        }


        public ActionResult ViewChart()
        {
            var data = db.AddCharts.Where(item => item.user_id == userId).ToList();
            return View(data);
        }


        public ActionResult DeleteChartItem(int id)
        {
            var existingCartItem = db.AddCharts.Find(id);
            db.AddCharts.Remove(existingCartItem);
            db.SaveChanges();
            return RedirectToAction("ViewChart");
        }


        public ActionResult IncreaseChartItem(int id)
        {
            var existingCartItem = db.AddCharts.SingleOrDefault(item => item.product_id == id);
            existingCartItem.product_quentity++;
            existingCartItem.total_price = existingCartItem.product_price * existingCartItem.product_quentity;
            db.SaveChanges();
            return RedirectToAction("ViewChart");
        }


        public ActionResult DecreaseChartItem(int id)
        {
            var existingCartItem = db.AddCharts.SingleOrDefault(item => item.product_id == id);

            //var existingCartItem = (from item in db.AddCharts
            //                        where item.product_id == id
            //                        select item).SingleOrDefault();
            if (existingCartItem != null)
            {
                if (existingCartItem.product_quentity > 1)
                {
                    existingCartItem.product_quentity--;
                    existingCartItem.total_price = existingCartItem.product_price * existingCartItem.product_quentity;
                    db.SaveChanges();
                }
                else
                {
                    db.AddCharts.Remove(existingCartItem);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ViewChart");
        }


        public ActionResult OrderConfirm()
        {
            var cartItems = db.AddCharts.Where(item => item.user_id == userId).ToList();

            if (cartItems.Any())
            {
                var order = new Order
                {
                    orderDate = DateTime.Now,
                    orderDay = DateTime.Now.ToString("dddd"),
                    orderTime = DateTime.Now.ToString("hh:mm tt"),
                    totalPrice = cartItems.Sum(item => item.total_price),
                    user_id = userId
                };
                db.Orders.Add(order);
                db.SaveChanges();

                foreach (var cartItem in cartItems)
                {
                    var history = new History
                    {
                        product_name = cartItem.product_name,
                        product_price = cartItem.product_price,
                        product_quentity = cartItem.product_quentity,
                        totalPrice = cartItem.total_price,
                        user_id = userId,
                        order_id = order.id // Link to the newly created order
                    };
                    db.Historys.Add(history);
                    db.SaveChanges();
                }

                // 4. Create ProductsOrder records for each product in the user's cart.
                foreach (var cartItem in cartItems)
                {
                    var productsOrder = new ProductsOrder
                    {
                        product_id = cartItem.product_id,
                        order_id = order.id // Link to the newly created order
                    };
                    db.ProductsOrders.Add(productsOrder);
                    db.SaveChanges();
                }

                if (cartItems.Any())
                {
                    db.AddCharts.RemoveRange(cartItems); // Remove all items from the cart
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ProductView");
        }

        public ActionResult OrderView()
        {
            var data = db.Orders.Where(item => item.user_id == userId).ToList();
            return View(data);
        }

        public ActionResult History()
        {
            var data = db.Historys.Where(item => item.user_id == userId).ToList();
            return View(data);
        }

        public ActionResult OrderDetails(int id)
        {
            var data = db.Historys.Where(item => item.order_id == id).ToList();
            return View(data);
        }
    }
}