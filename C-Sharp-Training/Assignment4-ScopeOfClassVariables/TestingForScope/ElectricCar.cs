using Assignment4_ScopeOfClassVariables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingForScope;

namespace TestingForScope
{
    internal class ElectricCar:Car
    {
        public string fuel = "Electric";
        public override void ShowInfo()
        {
            Console.WriteLine("public-  Brand: " + brand);
            Console.WriteLine("private- EngineNumber: //not inherited " );
            Console.WriteLine("protected-   Max Speed: " + maxSpeed);
            Console.WriteLine("internal-    Color: // outside namespace not accessible " );
            Console.WriteLine("protected internal-  Safety Rating: " + safetyRating + "    -Can be accesed either in internal classes or external subclass");
            Console.WriteLine("private protected- Feature: // outside namespace not accessible " );
            Console.WriteLine("Local variable- Fuel: " + fuel);

        }
    }
}
