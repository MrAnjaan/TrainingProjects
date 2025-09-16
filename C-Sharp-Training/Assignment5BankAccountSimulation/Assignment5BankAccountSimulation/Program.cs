using Assignment5BankAccountSimulation;
using System.Threading.Channels;


namespace Assignment5BankAccountSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating objects 
            Account KishanAccount = new Account("Account100", "Kishan", 5000); //Some banks (especially internationally or with IBANs) use letters
            Account VikasAccount = new Account("002233445566", "Vikas", 5000);
            Account VinayAccount = new Account("112233445577", "Vinay", 4500);
            Account SimranAccount = new Account("112233445588", "Simran", 17000);
            Account JagritiAccount = new Account("112233445599", "Jagriti", 17000);


            // creating a list of objects to pass in function
            List<Account> UserAccounts = new List<Account>() { KishanAccount, VikasAccount, VinayAccount, SimranAccount, JagritiAccount };

            // Variables for switch case
            double amount;
            bool isValidInput;


            Console.WriteLine("Welcome to bank account simulation");
            bool isOn = true;
            do
            {
                Console.WriteLine("\n\n1.Deposit money ");
                Console.WriteLine("2.Withdraw money ");
                Console.WriteLine("3.Transfer money ");
                Console.WriteLine("4.View Balnce money ");
                Console.WriteLine("5.Exit ");
                Console.WriteLine("\nEnter your choice ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    //Deposit Logic
                    case 1:
                        isValidInput = GetAmountInput(out amount);

                        if (isValidInput) VikasAccount.Deposit(amount);
                        
                        break;

                    // Withdraw Logic
                    case 2:
                        isValidInput = GetAmountInput(out amount);
                        if (isValidInput) VikasAccount.Withdraw(amount);

                        break;

                    //Transfer Logic
                    case 3:
                        isValidInput = GetAmountInput(out amount);
                        if (isValidInput) VikasAccount.Withdraw(amount);

                        Console.WriteLine("\nEnter Reciever account number:");
                        string receiverAccountNumber = (Console.ReadLine()).Trim();

                        VikasAccount.Transfer(receiverAccountNumber, amount, ref UserAccounts);
                        break;

                    // Balance Enquiry Logic
                    case 4:
                        VikasAccount.ShowBalance();
                        break;

                    // Case for Stopping the loop
                    case 5:
                        isOn = false;
                        break;

                    default:
                        Console.WriteLine("\nPlease enter a valid choice. \n");
                        break;
                }

            }
            while (isOn);

        }

        //Function for inputing and validating the amount input
        static bool GetAmountInput(out double amount)
        {
            Console.WriteLine("\nEnter amount:");
            if (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("\nEnter a valid numeric input.\n");
                return false;
            }
            return true;
        }
    }

}
