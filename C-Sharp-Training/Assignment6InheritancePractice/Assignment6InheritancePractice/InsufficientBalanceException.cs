namespace Assignment6InheritancePractice
{
    //Crating a custom Exception same ,as in java, extending exception calss
    public class InsufficientBalanceException : Exception
    {
        // message will be passed to parent exception class
        public InsufficientBalanceException(string message) : base(message) { }
    }

}
