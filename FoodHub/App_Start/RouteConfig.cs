using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodHub
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "OrderItemShow",
               url: "{controller}/{action}/{idM}/{idR}",
               defaults: new { controller = "OrderItem", action = "viewOrderItem" }
           );
          
            routes.MapRoute(
                name: "MealsCategory",
                url: "Meal/CategoryMeals/{id}",
                defaults: new { controller = "Meal", action = "CategoryMeals" }
            );
            routes.MapRoute(
               name: "RandomMeals",
               url: "Meal/RandomMeal",
               defaults: new { controller = "Meal", action = "RandomMeal" }
           );
            routes.MapRoute(
                name: "ShowRestaurants",
                url: "Restaurant/showRestaurants/{mealId}",
                defaults: new { controller = "Restaurant", action = "showRestaurants" }
            );
         
        }
    }
}
