namespace Assignment7FoodMenuApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to Food Menu Console Application ===");
            Console.WriteLine();

            var menuSystem = new MenuSystem();
            menuSystem.Start();

            Console.WriteLine("\nThank you for using our Food Menu Application!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
