using System.Drawing;

namespace Assignment4_ScopeOfClassVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Creating Car object :\nCalling car.ShowInfo()\n");
            var car = new Car();
            //Console.WriteLine($"Car Brand is : {car.brand}");
            car.ShowInfo();

            Console.WriteLine("\n\nCreating Sports car object (child)\nCalling sportsCar.showInfo()\n");
            var sportsCar = new SportsCar();
            //Console.WriteLine($"Sports car brand from parent Car class: {sportsCar.brand}, HorsePower :{sportsCar.horsePower}");
            sportsCar.ShowInfo();

            // trying to use in main
            Console.WriteLine("\n\n\nTrying to Access varaibles in Main directly\n\n");
            Console.WriteLine("public-  car.Brand: " + car.brand);
            Console.WriteLine("private- car.EngineNumber: // Error" );
            Console.WriteLine("protected-   car.Max Speed: //Error" );
            Console.WriteLine("internal-    car.Color: " + car.color);
            Console.WriteLine("protected internal-  car.SafetyRating: " + car.safetyRating);
            Console.WriteLine("private protected- car.specialFeature: //Error " );
        }
    }
}
