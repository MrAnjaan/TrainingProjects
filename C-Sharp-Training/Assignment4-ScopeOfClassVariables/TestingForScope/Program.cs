namespace TestingForScope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating an object of Electric Car - A subclass of Car in another namespace");
            var electricCar = new ElectricCar();

            Console.WriteLine("Calling ElectricCar.showInfo()\n");
            electricCar.ShowInfo();


        }
    }
}
