using Assignment7FoodMenuApplication.HelpingClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment7FoodMenuApplication.Modals;
using Assignment7FoodMenuApplication.Enums;
using Assignment7FoodMenuApplication.Interface;

namespace Assignment7FoodMenuApplication
{

    public class MenuSystem
    {
        private Order _currentOrder;  //Current order object
        private Dictionary<FoodCategory, List<IFoodItem>> _menuItems; // A dictionary containing menu and their items
        private List<FoodCategory> _categories;  // alist of Categories


        // constructor called
        public MenuSystem()
        {
            _currentOrder = new Order();
            _menuItems = MenuData.GetMenuItems();
            _categories = MenuData.GetCategories();
        }

        public void Start()
        {
            bool continueOrdering = true;

            while (continueOrdering)
            {
                DisplayMainMenu();  // functions called for displaying main menu

                int choice = InputValidator.GetValidIntegerInput("Enter your choice: ",1,4);

                switch (choice)
                {
                    case 1:
                        BrowseCategories();
                        break;
                    case 2:
                        ViewCurrentOrder();
                        break;
                    case 3:
                        if (ProcessOrderCompletion())
                        {
                            continueOrdering = false;
                        }
                        break;
                    case 4:
                        if (CancelOrder())
                        {
                            continueOrdering = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }



        // Main Menu Display function
        private void DisplayMainMenu()
        {
            Console.WriteLine("\n======= MAIN MENU =======");
            Console.WriteLine("1. Browse Food Categories");
            Console.WriteLine("2. View Current Order");
            Console.WriteLine("3. Complete Order");
            Console.WriteLine("4. Cancel Order & Exit");
            Console.WriteLine($"Current items in order: {_currentOrder.GetItemCount()}");
            Console.WriteLine("===========================\n");
        }


        // Function for Browsing the food categories
        private void BrowseCategories()
        {
            while (true)
            {
                DisplayCategories(); // first display categories

                string choice = InputValidator.GetValidInput("Enter category number (or 'back' to return): ");

                if (choice.ToLower() == "back")
                {
                    break;
                }

                // Attempt to parse input as a valid category index
                if (int.TryParse(choice, out int categoryIndex) &&
                    categoryIndex >= 1 && categoryIndex <= _categories.Count)
                {
                    FoodCategory selectedCategory = _categories[categoryIndex - 1];
                    DisplayCategoryItems(selectedCategory); // Show items in the selected category
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }


        // Displaying Categories Of the menu
        private void DisplayCategories()
        {
            Console.WriteLine("\n===== FOOD CATEGORIES =====");
            for (int i = 0; i < _categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_categories[i]}");
            }
            Console.WriteLine("===========================\n");
        }



        // Displayin Menu items on the screen\
        private void DisplayCategoryItems(FoodCategory category)
        {
            bool viewingCategory = true;

            while (viewingCategory)
            {
                Console.WriteLine($"\n===== {category} MENU =====");
                var items = _menuItems[category];

                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].GetDisplayInfo()}");
                }

                Console.WriteLine($"{items.Count + 1}. Back to Categories");
                Console.WriteLine("===========================\n");

                string choice = InputValidator.GetValidInput("Enter item number to add to order: ");

                if (int.TryParse(choice, out int itemIndex))  // slect food item index from food menu
                {
                    if (itemIndex >= 1 && itemIndex <= items.Count)
                    {
                        _currentOrder.AddItem(items[itemIndex - 1]); // adding in current order

                        Console.WriteLine("\nWould you like to:");
                        Console.WriteLine("1. Add another item from this category");
                        Console.WriteLine("2. Switch to another category");

                        int nextChoice = InputValidator.GetValidIntegerInput("Enter your choice: ",1,2);

                        switch (nextChoice)
                        {
                            case 1:
                                continue;
                            case 2:
                                viewingCategory = false; // stops the loop 
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Returning to category menu.");
                                break;
                        }
                    }
                    else if (itemIndex == items.Count + 1)
                    {
                        viewingCategory = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid item number. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }


        //Viewing cuurent order internally calling Displayorder summary
        private void ViewCurrentOrder()
        {
            _currentOrder.DisplayOrderSummary();
        }



        /// <summary>
        /// function for Processing Order. Shows bill and then ask if u want ot confirm order or cancel or Browse categories
        /// </summary>
        /// <returns>{True} when confirming order Otherwise False</returns>
        private bool ProcessOrderCompletion()
        {
            if (_currentOrder.GetItemCount() == 0)
            {
                Console.WriteLine("Your order is empty. Please add items before completing the order.");
                return false;
            }

            Console.WriteLine("\n===== ORDER COMPLETION =====");
            _currentOrder.DisplayOrderSummary();  // Display billl

            Console.WriteLine("\nWould you like to:");
            Console.WriteLine("1. Confirm Order");
            Console.WriteLine("2. Cancel Order");
            Console.WriteLine("3. Continue Shopping");

            int choice = InputValidator.GetValidIntegerInput("Enter your choice: ", 1, 3);

            // Swtich for order confirming or canceling
            switch (choice)
            {
                case 1:
                    ConfirmOrder();
                    return true;
                case 2:
                    return CancelOrder();
                case 3:
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Returning to main menu.");
                    return false;
            }
        }



        /// <summary>
        /// Function for Confirming the order and printing bill and final message on screen
        /// </summary>
        private void ConfirmOrder()
        {
            Console.WriteLine("\nOrder confirmed! Thank you for your purchase.");
            Console.WriteLine("Your order will be prepared shortly.");
        }



        // Cancels order , clears the list and exits the program
        private bool CancelOrder()
        {
            Console.WriteLine("\nAre you sure you want to cancel your order? (y/n)");
            string confirmation = InputValidator.GetValidInput("").ToLower();

            if (confirmation == "y" || confirmation == "yes")
            {
                _currentOrder.Clear();
                Console.WriteLine("\nOrder cancelled successfully. Transaction has been cancelled.");
                return true;
            }
            else
            {
                Console.WriteLine("Order cancellation aborted. Returning to main menu.");
                return false;
            }
        }
    }
}
