using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_ScopeOfClassVariables
{
    public class Car
    {
        public string brand = "Toyota";
        private readonly string engineNumber = "ENG45";
        protected int maxSpeed = 200;
        internal string color = "red";
        protected internal int safetyRating = 5;
        private protected string specialFeature = "Auto Pilot";
        
        public virtual void ShowInfo()
        {
            Console.WriteLine("public-  Brand: " + brand);
            Console.WriteLine("private- EngineNumber: " + engineNumber);
            Console.WriteLine("protected-   Max Speed: " + maxSpeed);
            Console.WriteLine("internal-    Color: " + color);
            Console.WriteLine("protected internal-  Safety Rating: " + safetyRating);
            Console.WriteLine("private protected- Feature: " + specialFeature);
        }
    }
}
