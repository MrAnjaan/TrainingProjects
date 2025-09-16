using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Assignment5BankAccountSimulation
{
    internal class Account
    {
        public string? AccountNumber { get; set; }
        public string? HolderName { get; set; }
        public double Balance { get; set; }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"\nDeposit Successfull!!\nAvailable balance- {Balance}");

        }

        public Account(string accountNumber, string holderName, double balance)
        {
            this.AccountNumber = accountNumber;
            this.HolderName = holderName;
            this.Balance = balance;
        }
        public void Withdraw(double amount)
        {
            if (Balance < amount)
            {
                Console.WriteLine("\nInsufficent Balance");
                return;
            }
            Balance -= amount;
            Console.WriteLine($"\nWithdrawal Successfull!!\nAvailable balance- {Balance}");
        }


        public void Transfer(string receiverAccountNumber, double amount, ref List<Account> userAccounts)
        {

            // INSUFFICIENT BALANCE
            if (Balance < amount)
            {
                Console.WriteLine("\nInsufficent Balance");
                return;
            }


            // LOOPING TO FIND ACCOUNT NUMBER
            foreach (var account in userAccounts)
            {

                // IF ACCOUNT NUMBER EXIST THEN TRANSFER THE MONEY
                if (account.AccountNumber == receiverAccountNumber)
                {
                    this.Balance -= amount;
                    account.Deposit(amount);
                    Console.WriteLine($"\nAmount: {amount} succesfully transferred to account no.- {receiverAccountNumber}.\nAvailable Balance- {this.Balance}  ");
                    return;
                }
            }

            // IF BOTH UPPER CONDITION FAILS MEANS THE ACCOUNT DOESNT EXIST
            Console.WriteLine($"\nInvalid Account number:\nThe acount number- {receiverAccountNumber} does not exist");

        }

        public void ShowBalance()
        {
            Console.WriteLine($"\nYour balance is {Balance}");
        }
    }
}
