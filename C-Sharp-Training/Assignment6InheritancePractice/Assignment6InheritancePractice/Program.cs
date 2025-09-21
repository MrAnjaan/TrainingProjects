using System.Security.Principal;

namespace Assignment6InheritancePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            try
            {
                decimal amount;
                // just an iterator
                SavingsAccount? userAccount;

                Console.WriteLine("Hello  Admin,\nWelcome to bank account simulation");

                while (true)
                {
                    Console.WriteLine("\n\n1. Create Account");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Show Balance");
                    Console.WriteLine("5. Add Interest");
                    Console.WriteLine("6. Show Available Accounts");
                    Console.WriteLine("7. Exit");
                    int choice = GetValidatedInputInt("\nEnter your choice ");

                    switch (choice)
                    {

                        case 1:

                            try
                            {
                                // Get and validate account type (1 or 2)
                                int accType = GetValidatedInputInt("Enter account type (1 - Savings, 2 - Premium Savings): ");
                                while (accType != 1 && accType != 2)
                                    accType = GetValidatedInputInt("Please, Enter a valid choice (1 - Savings, 2 - Premium Savings)");

                                // Get and validate account holder name
                                string name = GetValidatedInputName("\nEnter account holder name: ");

                                // Get and validate initial balance (positive)
                                decimal balance = GetValidatedInputDecimal("\nEnter initial balance: ");

                                // Get and validate interest rate (positive)
                                decimal rate = GetValidatedInputDecimal("\nEnter interest rate: ");
                                if (rate < 0 || rate > 100)
                                    rate = GetValidatedInputDecimal("\nEnter valid interest rate(must be in between 0 and 100): ");


                                if (accType == 1)
                                {
                                    SavingsAccount account = new(name, balance, rate);
                                    accounts.Add(account);
                                }
                                else if (accType == 2)
                                {
                                    PremiumSavingsAccount account = new(name, balance, rate);
                                    accounts.Add(account);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            break;

                        // Deposit Logic
                        case 2:
                            try
                            {
                                if (IsAccountListEmpty())
                                {
                                    Console.WriteLine("No account exists. Please create an account first.");
                                    break;
                                }

                                //getting account in useraccount or false in return

                                if (GetValidAccount(out userAccount))
                                {
                                    amount = GetValidatedInputDecimal("\nEnter amount to deposit: ");

                                    userAccount.Deposit(amount);

                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }

                            break;



                        //WithDrawal Logic
                        case 3:
                            try
                            {
                                if (IsAccountListEmpty())
                                {
                                    Console.WriteLine("No account exists. Please create an account first.");
                                    break;
                                }

                                //getting account in useraccount or false in return
                                if (GetValidAccount(out userAccount))
                                {
                                    amount = GetValidatedInputDecimal("\nEnter amount to withdraw: ");

                                    userAccount.Withdraw(amount);

                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"\n{ex.Message}");
                                break;
                            }

                        // Balance Enquiry Logic
                        case 4:
                            try
                            {
                                if (IsAccountListEmpty())
                                {
                                    Console.WriteLine("No account exists. Please create an account first.");
                                    break;
                                }

                                //getting account in useraccount or false in return
                                if (GetValidAccount(out userAccount))
                                {
                                    userAccount.ShowBalance();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            break;


                        // Add Interest
                        case 5:
                            try
                            {
                                if (IsAccountListEmpty())
                                {
                                    Console.WriteLine("No account exists. Please create an account first.");
                                    break;
                                }

                                //getting account in useraccount or false in return
                                if (GetValidAccount(out userAccount))
                                {
                                    userAccount.AddInterestToBalance();

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }

                            break;


                        // Printing Available accounts
                        case 6:
                            try
                            {
                                PrintAccounts(); //Calling function to print solution
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            break;

                        // Exit the Game case
                        case 7:
                            return;

                        //Default case to handle invalid number
                        default:
                            Console.WriteLine("\nPlease enter a valid choice. \n");
                            break;
                    }

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }


            // Function for Finding account in list
            SavingsAccount? FindSavingsAccount(string accountNumber)
            {
                SavingsAccount? account = (SavingsAccount?)accounts.Find(acc => acc.AccountNumber == accountNumber);
                return account;
            }


            // Function for inputing and validating account number
            bool GetValidAccount(out SavingsAccount userAccount)
            {
                string accountNumber = GetValidatedInputString("\nEnter the account number: ");

                userAccount = FindSavingsAccount(accountNumber);
                string ch = "y";

                while (userAccount == null && ch == "y")
                {
                    Console.WriteLine("\nEntered account number does not exists.");
                    Console.WriteLine("\nDo you want to enter again. Press 'Y/y' ");
                    ch = Console.ReadLine().Trim().ToLower();
                    if (ch != "y") break;
                    else
                    {
                        accountNumber = GetValidatedInputString("\nEnter the account number: ");
                        userAccount = FindSavingsAccount(accountNumber);
                    }
                }

                if (userAccount != null && ch == "y")
                {
                    return true;

                }
                return false;
            }

            // FUNCTION FOR CHECKING IS ACCOUNT EMPTY
            bool IsAccountListEmpty()
            {
                if (accounts.Count == 0) return true;
                return false;
            }

            //FUNCTION FOR PRINTING ACCOUNTS
            void PrintAccounts()
            {
                if (IsAccountListEmpty())
                {
                    Console.WriteLine("No account exists.");
                    return;
                }
                Console.WriteLine("\n\n"+new string('_', 40));
                Console.WriteLine("{0,-15}{1,25}", "AccountNumber", "AccountHolderName");
                Console.WriteLine(new string('_', 40));
                foreach (var account in accounts)
                {
                    Console.WriteLine("{0,-15}{1,25}", account.AccountNumber, account.AccountHolderName);
                }
                Console.WriteLine(new string('_', 40));

            }
        }


        // Function to get validated input for integers (positive only)
        /// <summary>Itisplays the prompt and gets an input string from user, parses it to integer and apply validation on it.</summary>
        /// <param name="intiger">The object to compare with the current object.</param>
        /// <returns><c>number</c> If user enters valid integer; otherwise, <c>keeps reasking for input</c>.</returns>
        public static int GetValidatedInputInt(string prompt)
        {
            int input;
            bool isValid;
            do
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                isValid = int.TryParse(userInput, out input);

                if (isValid && input > 0) // Validation: must be a positive integer
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValid ? "Input must be a nonzero positive integer." : "Invalid input. Please enter a valid integer.");
                }
            } while (true);

            return input;
        }



        // Function to get validated input for decimals (positive only)
        /// <summary>Itisplays the prompt and gets an input string from user, parses it to decimal and apply validation on it.</summary>
        /// <param name="decimal">The object to compare with the current object.</param>
        /// <returns><c>Decimal Number </c> If user enters valid decimal number; otherwise, <c>keeps reasking for input</c>.</returns>
        public static decimal GetValidatedInputDecimal(string prompt)
        {
            decimal input;
            bool isValid;
            do
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                isValid = decimal.TryParse(userInput, out input);

                if (isValid && input > 0) // Validation: must be a positive decimal
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValid ? "Input must be a nonzero positive integer." : "Invalid input. Please enter a valid number.");
                }
            } while (true);

            return input;
        }




        // Function to get validated input for Names 
        /// <summary>Itisplays the prompt and gets an input string from user and apply name validation on it.</summary>
        /// <param name="name">The object to compare with the current object.</param>
        /// <returns><c>name </c> If user enters valid name; otherwise, <c>keeps reasking for input</c>.</returns>
        public static string GetValidatedInputName(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                bool containsDigits = input.Any(char.IsDigit); // checking for digits
                bool containsSpecialCharacters = input.Any(ch => !char.IsLetterOrDigit(ch));

                if (!containsDigits && !containsSpecialCharacters && !string.IsNullOrWhiteSpace(input)) // Validation: input should not be empty
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Name cannot contain numbers, special characters or whitespaces");
                }
            } while (true);

            return input;
        }



        // Function to get validated input for strings (non-empty)
        /// <summary>Itisplays the prompt and gets an input string from user and apply  empty and whiteapces validation on it.</summary>
        /// <param name="string">The object to compare with the current object.</param>
        /// <returns><c>String </c> If user enters valid string; otherwise, <c>keeps reasking for input</c>.</returns>
        public static string GetValidatedInputString(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) // Validation: input should not be empty
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter valid input(Blank spaces are not allowed)");
                }
            } while (true);

            return input;
        }

    }
}
