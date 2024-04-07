
USE [aspnet-FoodHub2.mdf];


INSERT INTO [dbo].[MealIngredients] (MealId,IngredientId)
SELECT idI,idM
FROM [aspnet-FoodHub-20230711100623].[dbo].[temp];

