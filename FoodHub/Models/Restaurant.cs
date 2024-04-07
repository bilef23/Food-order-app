using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImgUrl { get;set; }
        [Required]
        public string Name { get;set; }
        [Required]
        public string Location { get;set; }
        [Required]
        public float Review { get; set; }
        [Required]
        public double AdditionalPrice { get; set; }
        public ICollection<MealRestaurant> MealRestaurants { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
      
    }
}