namespace Assignment6InheritancePractice
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        //Constructor

        public SavingsAccount(string accountHolderName, decimal balance, decimal interestRate)
            : base(accountHolderName, balance)
        {
            InterestRate = interestRate;
        }

        // interest returned on money
        public virtual decimal CalculateInterest()
        {
            return Balance * InterestRate / 100;
        }

        // Interest is calculated and added to the balance
        public void AddInterestToBalance()
        {
            decimal interest = CalculateInterest();
            Balance += interest;  // Add interest to the balance
            Console.WriteLine($"\nInterest of {interest} added. New Balance: {Balance}");
        }
    }

}
