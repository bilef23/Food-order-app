using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Item2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean isChecked { get; set; }
        public Meal Meal { get; set; }
        public Item2(int id, string name, bool isChecked)
        {
            Id = id;
            Name = name;
            this.isChecked = isChecked;
        }
        public Item2()
        {

        }
    }
}