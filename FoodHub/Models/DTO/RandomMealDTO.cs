
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FoodHub.Models.DTO
{
    public class RandomMealDTO
    {
       public string name {  get; set; }
        public int MealId { get; set; }
        public string urlImage { get; set; }
    }
}