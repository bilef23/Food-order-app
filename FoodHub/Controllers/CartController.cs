
using FoodHub.Models;
using FoodHub.Models.DTO;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FoodHub.Controllers
{
     
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        
       

        
        public ActionResult addToCart(OrderDTO dto)
            {
            
            try
            {



                string userId = User.Identity.GetUserId();
                ShoppingCart cart = db.Carts.Where(c => c.User.Id.Equals(userId)).FirstOrDefault();
                OrderItem item=db.OrderItems.Where(c => c.Id.Equals(dto.ItemId)).FirstOrDefault();
                item.quantity = dto.quantity;
                cart.Items.Add(item);
                cart.TotalPrice=cart.TotalPrice+dto.OrderPrice;
                db.OrderItems.AddOrUpdate(item);
                db.Carts.AddOrUpdate(cart);

                db.SaveChanges();

                    return Json(new { success = true, message = "Successfully added to cart." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Failed to add to cart. Error: " + ex.Message });
                }
            }
        [Authorize]
        public ActionResult viewCart() {
            string userId = User.Identity.GetUserId();
            ShoppingCart cart = db.Carts
                .Include(c => c.Items)
                .Where(c => c.User.Id.Equals(userId)).FirstOrDefault();
            foreach (var item in cart.Items)
            {
                db.OrderItems.Attach(item); // Attach item to the context
                db.Entry(item)
                    .Reference(mi => mi.Meal) // Reference to Meal navigation property within Item
                    .Load();
            }
            var l=cart.Items;
            return View(cart); 
        }
        [Authorize]
        public ActionResult Delete(int id) {

            var order = db.Orders.Where(o => o.Id.Equals(id));
            string userId = User.Identity.GetUserId();
            ShoppingCart cart = db.Carts.Where(c => c.User.Id.Equals(userId)).FirstOrDefault();
            var item= db.OrderItems.Where(o => o.Id.Equals(id)).FirstOrDefault();
            cart.Items.Remove(item);
            cart.TotalPrice = cart.TotalPrice - (item.price*item.quantity);
            db.OrderItems.Remove(item);
            db.Carts.AddOrUpdate(cart);
            db.SaveChanges();
                // Optionally, you can return a view or a redirect
                return RedirectToAction("viewCart");
            
        }
        [HttpPost]
        public ActionResult PlaceOrder( ) {



            try
            {
                string location = Request.Form["location"];
                string deliveryTime = Request.Form["deliveryTime"];
                string price = Request.Form["price"];
          

                
                
                DateTime orderTime = DateTime.Now;

                // Create a new Order object and populate its properties
                string userId = User.Identity.GetUserId();
                ShoppingCart cart = db.Carts.Where(c => c.User.Id.Equals(userId)).FirstOrDefault();

                var order = new Order();
                order.Location = location;
                
                order.DeliveryTime= Int16.Parse(deliveryTime);
                order.OrderTime = orderTime;
                order.TotalPrice = cart.TotalPrice;
                order.OrderItems = cart.Items;
               
                cart.Items = new List<OrderItem>();
                db.Carts.AddOrUpdate(cart);
                

                // Save the order to the database
                db.Orders.Add(order);
                db.SaveChanges();

                // Return success response
                return Json(new { success = true, message = "Successfully placed order." });
            }
            catch (Exception ex)
            {
                // Log error or handle exception
                return Json(new { success = false, message = "Failed to place the order. Error: " + ex.Message });
            }

        }
        
    }
}