using Assignment7FoodMenuApplication.Interface;

namespace Assignment7FoodMenuApplication.HelpingClass
{
    public class InputValidator : IInputValidator
    {

        // function that checks only nonempty value
        public static string GetValidInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }


        // Reads integer value in ranage
        public static int GetValidIntegerInput(string prompt, int min, int max)
        {
            int result;
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                if (result < min || result > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                    continue;
                }

                break;
            }
            while (true);

            return result;
        }


 
    }
}
