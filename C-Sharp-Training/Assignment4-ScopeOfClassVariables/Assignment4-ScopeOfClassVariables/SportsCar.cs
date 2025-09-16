using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4_ScopeOfClassVariables;

namespace Assignment4_ScopeOfClassVariables
{
    internal class SportsCar: Car
    {
        public int horsePower = 400;
        public override void ShowInfo()
        {
            Console.WriteLine("In Child Class");
            Console.WriteLine("public-  Brand: " + brand);
            Console.WriteLine("private- EngineNumber: // not inherited " );
            Console.WriteLine("protected-   Max Speed: " + maxSpeed);
            Console.WriteLine("internal-    Color: " + color);
            Console.WriteLine("protected internal-  Safety Rating: " + safetyRating);
            Console.WriteLine("private protected- Feature: " + specialFeature);
            Console.WriteLine("Local variable- Horse Power: " + horsePower);
        }
    }
}
