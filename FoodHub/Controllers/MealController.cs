
using FoodHub.Models.DTO;
using FoodHub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Data.Entity;

namespace FoodHub.Controllers
{
    public class MealController : Controller 
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult CategoryMeals(int id)
        {
            List<Meal> m = db.Meals
                .Include(meal => meal.Ingredients) 
                .Where(x => x.CategoryId.Equals(id)).ToList();
            foreach (var meal in m)
            {
                db.Entry(meal)
                    .Collection(q => q.Ingredients)
                    .Query()
                    .Include(mi => mi.Ingredient) 
                    .Load();
            }


            return View(m);
        }
        public ActionResult RandomMeal()
        {
            List<Meal> meals = db.Meals.ToList();
            List<RandomMealDTO> randomMeals = new List<RandomMealDTO>();
            foreach (var meal in meals)
            {
                RandomMealDTO temp = new RandomMealDTO();
                temp.MealId = meal.Id;
                temp.name = meal.name;
                temp.urlImage = meal.urlImage;
                randomMeals.Add(temp);
            }

            return View(randomMeals);
        }
    }
}