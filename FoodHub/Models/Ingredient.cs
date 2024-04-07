using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Ingredient
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<MealIngredient> MealIngredients { get; set; }
    }
}