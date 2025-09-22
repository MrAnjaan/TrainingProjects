using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment7FoodMenuApplication.Interface;
using Assignment7FoodMenuApplication.Modals;
using Assignment7FoodMenuApplication.Enums;

namespace Assignment7FoodMenuApplication.Modals
{
    public class FoodItem:IFoodItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public FoodItem(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        // for displaing info of each food item
        public  string GetDisplayInfo()
        {
            return $"{Name} - ${Price:F2}";
        }
    }
}
