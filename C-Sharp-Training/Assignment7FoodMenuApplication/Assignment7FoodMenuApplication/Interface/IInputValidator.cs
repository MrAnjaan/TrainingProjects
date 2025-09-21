using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7FoodMenuApplication.Interface
{
    public interface IInputValidator
    {

    //interface can contain static abstract methods, so that u can declare static methids
        static abstract string GetValidInput(string prompt);
        static abstract int GetValidIntegerInput(string prompt, int min, int max);
        //static abstract bool ValidateYesNoInput(string input);
    }
}
