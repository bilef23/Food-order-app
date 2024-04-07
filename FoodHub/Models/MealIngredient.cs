
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace FoodHub.Models
{
    public class MealIngredient
    {
        [Key]
        [Column(Order = 0)]
        public int MealId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int IngredientId { get; set; }
        [ForeignKey("MealId")]
        public Meal Meal { get; set; }
        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }
    }
}