using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public virtual ICollection<MealIngredient> Ingredients { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string urlImage { get; set; }
        [JsonIgnore]
        public ICollection <MealRestaurant> MealRestaurants { get; set; }
        [JsonIgnore]
        public ICollection <OrderItem> OrderItems { get; set; }
        public double BasePrice { get; set; }
    }
}