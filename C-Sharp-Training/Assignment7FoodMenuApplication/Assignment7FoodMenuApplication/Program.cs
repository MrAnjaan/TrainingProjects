namespace Assignment7FoodMenuApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to Food Menu Console Application ===");
            Console.WriteLine();

            // creating an instance of menu system and starting it
            var menuSystem = new MenuSystem();
            menuSystem.Start();

            Console.WriteLine("\nThank you for using our Food Menu Application!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
