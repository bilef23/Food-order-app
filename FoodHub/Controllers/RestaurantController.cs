
using FoodHub.Models.DTO;
using FoodHub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FoodHub.Controllers
{
    public class RestaurantController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult showRestaurants(int id)
        {
            Meal m = db.Meals.Find(id);
            List<Restaurant> restaurants = db.MealRestaurants.Where(x => x.MealId.Equals(id)).Select(x => x.Restaurant).ToList();
            RestaurantMealDTO model = new RestaurantMealDTO();
            model.Restaurants = restaurants;
            model.Meal = m;
            return View(model);
        }
    }
}