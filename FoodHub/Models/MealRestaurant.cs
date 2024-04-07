using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class MealRestaurant
    {
        [Key]
        [Column(Order = 0)]
        public int MealId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int RestaurantId { get; set; }
        [ForeignKey("MealId")]
        public Meal Meal { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
    }
}