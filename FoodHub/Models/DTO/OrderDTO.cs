
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FoodHub.Models.DTO
{
    public class OrderDTO
    {
        public OrderItem OrderItem { get; set; }
       public int ItemId { get; set; }
        public List<Boolean> isChecked { get; set; }
       public int quantity { get; set; }
        public double OrderPrice { get; set; }
    }
}