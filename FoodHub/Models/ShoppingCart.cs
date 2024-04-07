using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace FoodHub.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public double TotalPrice {  get; set; }
        public List<OrderItem> Items { get; set; }
        public ShoppingCart() { 
        Items=new List<OrderItem>();
        }
    }
}