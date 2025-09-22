using Assignment7FoodMenuApplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7FoodMenuApplication.Modals
{
    public class Order 
    {
        private Dictionary <IFoodItem, int> _items;
       
        //constructor for order List
        public Order()
        {
            _items = new Dictionary<IFoodItem, int>();
        }


        //Function for adding item with quantity in order list
        public void AddItem(IFoodItem item)
        {
            if (!_items.ContainsKey(item))
                _items[item] = 0;

            _items[item]++;
            Console.WriteLine($"Added: {item.Name} to your order");
        }



        // Returns total price Key.price(fooditem.price) * value(qty)
        public decimal GetTotal()
        {
            return _items.Sum(item => item.Key.Price * item.Value);
        }


        //REturns total number of items in order including duplicates
        public int GetItemCount()
        {
            return _items.Sum(item => item.Value);
        }


        //Clears the order
        public void Clear()
        {
            _items.Clear();
        }
 
        //Displays the details of the orders
        public void DisplayOrderSummary()
        {
            Console.WriteLine("\n============================ ORDER SUMMARY ===========================");

            if (_items.Count == 0)
            {
                Console.WriteLine("Your order is empty.");
                return;
            }

            // Display the header of the table
            Console.WriteLine("{0,-5} {1,-40} {2,10} {3,10}", "No.", "Item", "Quantity", "Price");
            Console.WriteLine(new String('_',70));

            // Display the items in tabular format
            int i = 1;
            foreach (var item in _items)
            {
                // Adjust the formatting to your preferences
                Console.WriteLine("{0,-5} {1,-40} {2,10} {3,10:F2}",
                    i,
                    item.Key.GetDisplayInfo(),
                    item.Value,
                    item.Key.Price * item.Value); // Assuming `GetPrice()` exists for each item.
                i++;
            }

            // Display the total amount at the bottom
            Console.WriteLine("\n{0,-5} {1,-40} {2,10} {3,10:F2}", "", "Total Amount:", "", GetTotal());

            Console.WriteLine(new String('=',70)+ "\n");
        }

    }
}
