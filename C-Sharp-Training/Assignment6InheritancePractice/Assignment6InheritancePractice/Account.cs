
namespace Assignment6InheritancePractice
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }

        private static int _counter = 0;

        // constructor
        public Account(string accountHolderName, decimal balance)
        {
            try
            {
                AccountNumber = GenerateUniqueAccountNumber();
                AccountHolderName = accountHolderName;
                Balance = balance;
                Console.WriteLine($"\nAccount created successfully!!\nYour account number is {AccountNumber}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // deposit function
        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"\nAmount {amount} deposited to account number {this.AccountNumber}, successfully!!!");
        }

        //withdraw function
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Insufficient balance");
            }
            Balance -= amount;
            Console.WriteLine($"\nAmount {amount} withdrawn from account number {this.AccountNumber}, successfully!!!");

        }

        //Show balance
        public void ShowBalance()
        {
            Console.WriteLine($"\nYour available balance is {Balance} ");
        }

        // Generate a unique account number using an incrementing counter
        private string GenerateUniqueAccountNumber()
        {
            _counter++;
            return $"ACCT{_counter:D4}"; // Formats number as ACCT0001, ACCT0002, etc.
        }
    }
}

