using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string Location { get; set; }
        public int DeliveryTime { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderItem> OrderItems { get; set; }


    }
}