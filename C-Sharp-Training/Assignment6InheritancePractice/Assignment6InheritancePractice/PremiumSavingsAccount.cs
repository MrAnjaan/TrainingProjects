namespace Assignment6InheritancePractice
{
    public class PremiumSavingsAccount : SavingsAccount
    {
        private decimal exclusiveRate = 10;
        public PremiumSavingsAccount(string accountHolderName, decimal balance, decimal interestRate)
            : base(accountHolderName, balance, interestRate)
        {
            //does nothing, parent constructor called
        }

        // premium member will get more interest back
        public override decimal CalculateInterest()
        {
            decimal basicInterest = Balance * InterestRate / 100;
            return basicInterest * (1 + exclusiveRate / 100);
        }
    }
}
