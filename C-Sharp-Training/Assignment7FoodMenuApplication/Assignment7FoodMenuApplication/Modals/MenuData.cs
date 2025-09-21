using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment7FoodMenuApplication.Modals;
using Assignment7FoodMenuApplication.Enums;
using Assignment7FoodMenuApplication.Interface;

namespace Assignment7FoodMenuApplication.Modals
{
    public static class MenuData
    {
        public static Dictionary<FoodCategory, List<IFoodItem>> GetMenuItems()
        {
            return new Dictionary<FoodCategory, List<IFoodItem>>
            {
                [FoodCategory.Starters] = new List<IFoodItem>
                {
                    new FoodItem("Salad", 8.99m, "Starters"),
                    new FoodItem("Chicken Wings", 12.99m, "Starters"),
                    new FoodItem("Aaloo Sticks", 9.99m, "Starters"),
                    new FoodItem("Garlic Bread", 6.99m, "Starters"),
                    new FoodItem("Onion Rings", 7.99m, "Starters"),
                    new FoodItem("Nachos", 11.99m, "Starters")
                },

                [FoodCategory.Chinese] = new List<IFoodItem>
                {
                    new FoodItem("Sweet and Sour Chicken", 15.99m, "Chinese"),
                    new FoodItem("Beef and Broccoli", 16.99m, "Chinese"),
                    new FoodItem("Kung Pao Chicken", 14.99m, "Chinese"),
                    new FoodItem("Fried Rice", 12.99m, "Chinese"),
                    new FoodItem("Lo Mein Noodles", 13.99m, "Chinese"),
                    new FoodItem("General Tso's Chicken", 15.99m, "Chinese")
                },

                [FoodCategory.MainCourse] = new List<IFoodItem>
                {
                    new FoodItem("Sahi Paneer Thali", 22.99m, "Main Course"),
                    new FoodItem("Rajma Chawal", 28.99m, "Main Course"),
                    new FoodItem("Chicken Parmesan", 18.99m, "Main Course"),
                    new FoodItem("BBQ Ribs", 24.99m, "Main Course"),
                    new FoodItem("Vegetarian Pasta", 16.99m, "Main Course"),
                    new FoodItem("Fish and Chips", 17.99m, "Main Course")
                },

                [FoodCategory.Desserts] = new List<IFoodItem>
                {
                    new FoodItem("Chocolate Cake", 7.99m, "Desserts"),
                    new FoodItem("Cheesecake", 8.99m, "Desserts"),
                    new FoodItem("Ice Cream Sundae", 6.99m, "Desserts"),
                    new FoodItem("Apple Pie", 7.49m, "Desserts"),
                    new FoodItem("Tiramisu", 9.99m, "Desserts"),
                    new FoodItem("Chocolate Brownie", 6.99m, "Desserts")
                },

                [FoodCategory.Beverages] = new List<IFoodItem>
                {
                    new FoodItem("Chai", 10, "Beverages"),
                    new FoodItem("Coffee",20, "Beverages"),
                    new FoodItem("Lemon Soda", 6.99m, "Beverages"),
                    new FoodItem("Fruit Beer", 7.49m, "Beverages"),
                    new FoodItem("Coke", 9.99m, "Beverages"),
                    new FoodItem("Sprite", 6.99m, "Beverages")
                },
            };
        }

        public static List<FoodCategory> GetCategories()
        {
            return new List<FoodCategory>
            {
                FoodCategory.Starters,
                FoodCategory.Chinese,
                FoodCategory.MainCourse,
                FoodCategory.Desserts,
                FoodCategory.Beverages
            };
        }

        //public static string GetCategoryDisplayName(FoodCategory category)
        //{
        //    return category switch
        //    {
        //        FoodCategory.Starters => "Starters",
        //        FoodCategory.Chinese => "Chinese",
        //        FoodCategory.MainCourse => "Main Course",
        //        FoodCategory.Desserts => "Desserts",
        //        _ => category.ToString()
        //    };
        //}
    }
}
