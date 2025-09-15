
using Assignment3_PasswordValidator;

int numberOfChances = 5; // How many times uer can enter invalid output

Console.WriteLine("Enter your Name: ");
string name = Console.ReadLine();

Console.WriteLine($"\nHii {name},\nPlease create a password:\n ");
Console.WriteLine("Follow the instructions given below for creating password");
Console.WriteLine("Be at least 8 characters long\r\nContain at least one uppercase letter\r\nContain at least one lowercase letter\r\nContain at least one digit\r\nContain at least one special character\r\nMust not contain blank space\n");
string password = Console.ReadLine();

string errorMessage;

bool isValid = PasswordValidator.Validate(password, out errorMessage);

while (!isValid && numberOfChances>1)
{
    --numberOfChances;
    Console.WriteLine($"\nInvalid input\n{errorMessage}\nChances left: {numberOfChances}\n");
    Console.WriteLine("\nPlease Enter a valid password: ");
    password = Console.ReadLine();
    isValid = PasswordValidator.Validate(password, out errorMessage);

}

if (numberOfChances > 0)
    Console.WriteLine("Your password is valid");
else
    Console.WriteLine("Maximum limit exceeded\nTry again tomorrow");

