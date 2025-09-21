using Assignment5BankAccountSimulation;
using System.Threading.Channels;


namespace Assignment5BankAccountSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //creating objects 
            Account KishanAccount = new("Account100", "Kishan", 5200); //Some banks (especially internationally or with IBANs) use letters
            Account VikasAccount = new("Account101", "Vikas", 5000);
            Account VinayAccount = new("Account102", "Vinay", 4500);
            Account SimranAccount = new("Account103", "Simran", 17000);
            Account JagritiAccount = new("Account104", "Jagriti", 17000);


            // creating a list of objects to pass in function
            List<Account> UserAccounts = [KishanAccount, VikasAccount, VinayAccount, SimranAccount, JagritiAccount];

          

            // Variables for switch case
            double amount;
            bool isValidInput;


            Console.WriteLine("Hello  Vikas,\nWelcome to bank account simulation");
            bool isOn = true;
            do
            {
                Console.WriteLine("\n\n1.Deposit money ");
                Console.WriteLine("2.Withdraw money ");
                Console.WriteLine("3.Transfer money ");
                Console.WriteLine("4.View Balance money ");
                Console.WriteLine("5.Exit ");
                Console.WriteLine("\nEnter your choice ");
                int choice; 
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nEnter valid input: ");
                }
                switch (choice)
                {
                    //Deposit Logic
                    case 1:
                        GetAmountInput(out amount);
                        VikasAccount.Deposit(amount);

                        break;

                    // Withdraw Logic
                    case 2:
                        GetAmountInput(out amount);
                        VikasAccount.Withdraw(amount);

                        break;

                    //Transfer Logic
                    case 3:
                        
                        string receiverAccountNumber= GetReceiverAccountInput();
                        if (receiverAccountNumber == null) break;

                        GetAmountInput(out amount);
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



              //Function for getting user account
            string GetReceiverAccountInput()
            {
                Console.WriteLine("\nEnter Reciever account number:");
                string receiverAccountNumber = (Console.ReadLine()).Trim();
                foreach (var account in UserAccounts)
                {

                    // IF ACCOUNT NUMBER EXIST THEN TRANSFER THE MONEY
                    if (account.AccountNumber == receiverAccountNumber)
                    {
                        return account.AccountNumber;
                        
                    }
                }

                Console.WriteLine($"\nInvalid Account number:\nThe acount number- {receiverAccountNumber} does not exist");
                Console.WriteLine("If you want to re enter the account number, press Y");
                string userInput = Console.ReadLine();
                if(userInput.ToLower() == "y" ) return GetReceiverAccountInput();
                return null;
            }
        }

        //Function for inputing and validating the amount input
        public static void GetAmountInput(out double amount)
        {
            Console.WriteLine("\nEnter amount:");
            string userInput = Console.ReadLine();
            while (!double.TryParse(userInput, out amount) || amount <= 0)
            {
                Console.WriteLine("\nPlease enter a valid amount.\n");
                userInput = Console.ReadLine();
            }
        }


    }

}
