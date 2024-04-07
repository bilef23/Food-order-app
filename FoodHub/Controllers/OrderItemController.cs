
using FoodHub.Models;
using FoodHub.Models.DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
namespace FoodHub.Controllers
{
    public class OrderItemController: Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult viewOrderItem(int idM, int idR)
        {
            string userId = User.Identity.GetUserId();
            ShoppingCart cart = db.Carts.Where(c => c.User.Id.Equals(userId)).FirstOrDefault();
            Meal m = db.Meals
                .Include(meal => meal.Ingredients) // Include Ingredients navigation property within Meal
                .Where(x => x.Id.Equals(idM)).FirstOrDefault();

            db.Entry(m)
                .Collection(q => q.Ingredients)
                .Query()
                .Include(mi => mi.Ingredient) // Include Ingredient navigation property within MealIngredient
                .Load();

            Restaurant r = db.Restaurants.Find(idR);
            OrderDTO orderDTO = new OrderDTO();
            OrderItem orderItem = new OrderItem();
            orderItem.MealId = idM;
            orderItem.Meal = m;

            orderItem.Restaurant = r;
            orderItem.RestaurantId = idR;
            orderItem.ShoppingCartId = cart.Id;
            orderItem.price = m.BasePrice + r.AdditionalPrice;
            orderDTO.OrderPrice = orderItem.price;
            orderDTO.OrderItem = orderItem;

            orderDTO.isChecked = new List<bool>(m.Ingredients.Count);
            for (int i = 0; i < m.Ingredients.Count; i++)
            {
                orderDTO.isChecked.Add(false);
            }
            db.OrderItems.Add(orderItem);
            db.SaveChanges();
            var lastOrderItem = db.OrderItems.OrderByDescending(item => item.Id).FirstOrDefault();

            orderDTO.ItemId = lastOrderItem.Id;
            return View(orderDTO);
        }
    }
}