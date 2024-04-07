using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FoodHub.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}