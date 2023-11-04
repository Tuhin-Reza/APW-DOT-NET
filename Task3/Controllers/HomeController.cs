using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3.AUTH;
using Task3.EF;
using Task3.Models;

namespace Task3.Controllers
{
    [Logged]
    public class HomeController : Controller
    {
        private Task3DBEntities db;
        private HttpCookie cartCookie;
        public HomeController()
        {
            db = new Task3DBEntities();
            cartCookie = new HttpCookie("CartItems");
        }

        public ActionResult Signout()
        {
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("Signin", "Register");
        }

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

            List<CartItem> cartItemList = new List<CartItem>();
            if (Request.Cookies["CartItems"] != null)
            {
                var cartData = Request.Cookies["CartItems"].Value;
                cartItemList = JsonConvert.DeserializeObject<List<CartItem>>(cartData);
            }
            bool productExistsInCart = false;

            foreach (var item in cartItemList)
            {
                if (item.ProductId == id)
                {
                    item.ProductQuantity++;
                    item.TotalPrice = item.ProductPrice * item.ProductQuantity;
                    productExistsInCart = true;
                    break;
                }
            }

            if (!productExistsInCart)
            {
                CartItem item = new CartItem
                {
                    ProductId = product.id,
                    ProductName = product.name,
                    ProductPrice = product.price,
                    ProductQuantity = 1,
                    TotalPrice = product.price,
                    UserId = SessionUser.id
                };
                cartItemList.Add(item);
            }

            string updatedCartData = JsonConvert.SerializeObject(cartItemList);
            updateCartCookie(updatedCartData);
            return RedirectToAction("ProductView");
        }

        public ActionResult ViewChart()
        {

            List<CartItem> cartItemList = new List<CartItem>();
            if (Request.Cookies["CartItems"] != null)
            {
                var cartData = Request.Cookies["CartItems"].Value;
                cartItemList = JsonConvert.DeserializeObject<List<CartItem>>(cartData);
            }
            foreach (var item in cartItemList)
            {
                if (item.UserId == SessionUser.id)
                {
                    return View(cartItemList);
                }
            }
            return View();
        }

        public ActionResult DeleteChartItem(int id)
        {
            List<CartItem> cartItemList = new List<CartItem>();
            if (Request.Cookies["CartItems"] != null)
            {
                var cartData = Request.Cookies["CartItems"].Value;
                cartItemList = JsonConvert.DeserializeObject<List<CartItem>>(cartData);
            }
            var itemToRemove = (from item in cartItemList
                                where item.ProductId == id
                                select item).SingleOrDefault();
            if (itemToRemove != null)
            {
                cartItemList.Remove(itemToRemove);
            }


            string updatedCartData = JsonConvert.SerializeObject(cartItemList);
            updateCartCookie(updatedCartData);
            return RedirectToAction("ViewChart");
        }

        public ActionResult IncreaseChartItem(int id)
        {
            List<CartItem> cartItemList = new List<CartItem>();
            if (Request.Cookies["CartItems"] != null)
            {
                var cartData = Request.Cookies["CartItems"].Value;
                cartItemList = JsonConvert.DeserializeObject<List<CartItem>>(cartData);
            }
            foreach (var item in cartItemList)
            {
                if (item.ProductId == id)
                {
                    item.ProductQuantity++;
                    item.TotalPrice = item.ProductPrice * item.ProductQuantity;
                    break;
                }
            }
            string updatedCartData = JsonConvert.SerializeObject(cartItemList);
            updateCartCookie(updatedCartData);
            return RedirectToAction("ViewChart");
        }

        public ActionResult DecreaseChartItem(int id)
        {
            List<CartItem> cartItemList = new List<CartItem>();
            if (Request.Cookies["CartItems"] != null)
            {
                var cartData = Request.Cookies["CartItems"].Value;
                cartItemList = JsonConvert.DeserializeObject<List<CartItem>>(cartData);
            }
            foreach (var item in cartItemList)
            {
                if (item.ProductId == id)
                {
                    if (item.ProductQuantity > 1)
                    {
                        item.ProductQuantity--;
                        item.TotalPrice = item.ProductPrice * item.ProductQuantity;
                        break;
                    }

                }
            }
            string updatedCartData = JsonConvert.SerializeObject(cartItemList);
            updateCartCookie(updatedCartData);
            return RedirectToAction("ViewChart");

        }

        public ActionResult OrderConfirm()
        {

            List<CartItem> cartItemList = new List<CartItem>();
            if (Request.Cookies["CartItems"] != null)
            {
                var cartData = Request.Cookies["CartItems"].Value;
                cartItemList = JsonConvert.DeserializeObject<List<CartItem>>(cartData);
            }
            if (cartItemList != null)
            {
                var order = new Order
                {
                    orderDate = DateTime.Now,
                    orderDay = DateTime.Now.ToString("dddd"),
                    orderTime = DateTime.Now.ToString("hh:mm tt"),
                    totalPrice = (from item in cartItemList
                                  select item.TotalPrice).Sum(),
                    user_id = SessionUser.id
                };
                db.Orders.Add(order);
                db.SaveChanges();

                foreach (var cartItem in cartItemList)
                {
                    var history = new History
                    {
                        product_name = cartItem.ProductName,
                        product_price = cartItem.ProductPrice,
                        product_quentity = cartItem.ProductQuantity,
                        totalPrice = cartItem.TotalPrice,
                        user_id = SessionUser.id,
                        order_id = order.id // Link to the newly created order
                    };
                    db.Historys.Add(history);
                    db.SaveChanges();
                }

                // 4. Create ProductsOrder records for each product in the user's cart.
                foreach (var cartItem in cartItemList)
                {
                    var productsOrder = new ProductsOrder
                    {
                        product_id = cartItem.ProductId,
                        order_id = order.id // Link to the newly created order
                    };
                    db.ProductsOrders.Add(productsOrder);
                    db.SaveChanges();
                }

                cartCookie.Expires = DateTime.Now.AddSeconds(-1);
                Response.Cookies.Add(cartCookie);
            }
            TempData["confirm"] = "done";
            return RedirectToAction("OrderView");
        }

        public ActionResult OrderView()
        {
            var orderlist = (from Items in db.Orders
                             where Items.user_id == SessionUser.id
                             select Items).ToList();

            return View(orderlist);
        }

        public ActionResult History()
        {
            var history = (from Items in db.Historys
                           where Items.user_id == SessionUser.id
                           select Items).ToList();

            return View(history);
        }

        public ActionResult OrderDetails(int id)
        {
            var orderdetails = (from Items in db.Historys
                                where Items.order_id == id
                                select Items).ToList();
            return View(orderdetails);
        }

        private void updateCartCookie(string cartData)
        {
            cartCookie.Value = cartData;
            cartCookie.Expires = DateTime.Now.AddSeconds(240);
            Response.Cookies.Add(cartCookie);
        }
        private User SessionUser
        {
            get
            {
                return Session["UserData"] as User;
            }
        }
    }
}