using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3PasswordValidator
{
    internal class PasswordValidator
    {
        public static bool Validate(string password, out string errorMessage)
        {
            errorMessage = ""; // default value set for out variable

            //empty validation
            if (String.IsNullOrEmpty(password))
            {
                errorMessage = "Password cannot be null or empty ";
                return false;
            }

            // Length validation
            if (password.Length < 8)
            {
                errorMessage = "Password must be atleast 8 characters long ";
                return false;
            }

            //atleast 1 upper
            if (!password.Any(char.IsUpper))
            {
                errorMessage = "Password must contain atleast one upper case character ";
                return false;
            }

            // Atleast one lower
            if (!password.Any(char.IsLower))
            {
                errorMessage = "Password must contain atleast one lower case character ";
                return false;
            }

            // Atleast 1 digit
            if (!password.Any(char.IsDigit))
            {
                errorMessage = "Password must contain atleast one numerical digit ";
                return false;
            }

            // Atleast 1 sepcial character
            if (!password.Any(ch => ! char.IsLetterOrDigit(ch)))
            {
                errorMessage = "Password must contain atleast one special case character";
                return false;
            }



            // No blankspaces allowed
            if (password.Any(char.IsWhiteSpace))
            {
                errorMessage = "Password must not contain blank spaces ";
                return false;
            }

            return true;
        }
    }
}










//bool specialCharFound = false;
//foreach (var item in password)
//{
//    if (!char.IsLetterOrDigit(item))
//        specialCharFound = true;
//}

//if (!specialCharFound)
//{
//    errorMessage = "Password must contain atleast one special character";
//    return false;
//}