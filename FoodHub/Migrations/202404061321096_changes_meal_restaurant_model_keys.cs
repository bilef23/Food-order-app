namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes_meal_restaurant_model_keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MealRestaurants", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.MealRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.MealRestaurants", new[] { "Meal_Id" });
            DropIndex("dbo.MealRestaurants", new[] { "Restaurant_Id" });
            DropColumn("dbo.MealRestaurants", "MealId");
            DropColumn("dbo.MealRestaurants", "RestaurantId");
            RenameColumn(table: "dbo.MealRestaurants", name: "Meal_Id", newName: "MealId");
            RenameColumn(table: "dbo.MealRestaurants", name: "Restaurant_Id", newName: "RestaurantId");
            DropPrimaryKey("dbo.MealRestaurants");
            AlterColumn("dbo.MealRestaurants", "MealId", c => c.Int(nullable: false));
            AlterColumn("dbo.MealRestaurants", "RestaurantId", c => c.Int(nullable: false));
            AlterColumn("dbo.MealRestaurants", "MealId", c => c.Int(nullable: false));
            AlterColumn("dbo.MealRestaurants", "RestaurantId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MealRestaurants", new[] { "MealId", "RestaurantId" });
            CreateIndex("dbo.MealRestaurants", "MealId");
            CreateIndex("dbo.MealRestaurants", "RestaurantId");
            AddForeignKey("dbo.MealRestaurants", "MealId", "dbo.Meals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MealRestaurants", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
            DropColumn("dbo.MealRestaurants", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MealRestaurants", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.MealRestaurants", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.MealRestaurants", "MealId", "dbo.Meals");
            DropIndex("dbo.MealRestaurants", new[] { "RestaurantId" });
            DropIndex("dbo.MealRestaurants", new[] { "MealId" });
            DropPrimaryKey("dbo.MealRestaurants");
            AlterColumn("dbo.MealRestaurants", "RestaurantId", c => c.Int());
            AlterColumn("dbo.MealRestaurants", "MealId", c => c.Int());
            AlterColumn("dbo.MealRestaurants", "RestaurantId", c => c.String());
            AlterColumn("dbo.MealRestaurants", "MealId", c => c.String());
            AddPrimaryKey("dbo.MealRestaurants", "Id");
            RenameColumn(table: "dbo.MealRestaurants", name: "RestaurantId", newName: "Restaurant_Id");
            RenameColumn(table: "dbo.MealRestaurants", name: "MealId", newName: "Meal_Id");
            AddColumn("dbo.MealRestaurants", "RestaurantId", c => c.String());
            AddColumn("dbo.MealRestaurants", "MealId", c => c.String());
            CreateIndex("dbo.MealRestaurants", "Restaurant_Id");
            CreateIndex("dbo.MealRestaurants", "Meal_Id");
            AddForeignKey("dbo.MealRestaurants", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.MealRestaurants", "Meal_Id", "dbo.Meals", "Id");
        }
    }
}
