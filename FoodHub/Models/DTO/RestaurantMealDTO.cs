using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FoodHub.Models.DTO
{
    public class RestaurantMealDTO
    {
        public List<Restaurant> Restaurants { get; set; }
        public Meal Meal { get; set; }
    }
}