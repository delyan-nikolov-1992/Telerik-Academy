namespace Bank
{
    using System;

    public class Shell
    {
        private const uint numberOfMonths = 6;

        public static void Main()
        {
            try
            {
                // test the depositAccount
                Account depositAccount = new DepositAccount(Customer.Individual, 500, 0.10m);
                Console.WriteLine(depositAccount.GetType().Name + ":\n");
                Console.WriteLine("Before:\n{0}", depositAccount.ToString());
                depositAccount.Deposit(500);
                depositAccount.Withdraw(300);
                Console.WriteLine("The interest for {0} months is {1}\n", numberOfMonths, 
                    depositAccount.CalculateInterest(numberOfMonths));
                Console.WriteLine("After:\n{0}", depositAccount.ToString());

                // // test the loanAccount
                Account loanAccount = new LoanAccount(Customer.Company, 30000, 0.25m);
                Console.WriteLine(loanAccount.GetType().Name + ":\n");
                Console.WriteLine("Before:\n{0}", loanAccount.ToString());
                loanAccount.Deposit(500);
                Console.WriteLine("The interest for {0} months is {1}\n", numberOfMonths,
                    loanAccount.CalculateInterest(numberOfMonths));
                Console.WriteLine("After:\n{0}", loanAccount.ToString());

                // // test the mortgageAccount
                Account mortgageAccount = new MortgageAccount(Customer.Company, 35000, 0.15m);
                Console.WriteLine(mortgageAccount.GetType().Name + ":\n");
                Console.WriteLine("Before:\n{0}", mortgageAccount.ToString());
                mortgageAccount.Deposit(500);
                Console.WriteLine("The interest for {0} months is {1}\n", numberOfMonths,
                    mortgageAccount.CalculateInterest(numberOfMonths));
                Console.WriteLine("After:\n{0}", mortgageAccount.ToString());
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}