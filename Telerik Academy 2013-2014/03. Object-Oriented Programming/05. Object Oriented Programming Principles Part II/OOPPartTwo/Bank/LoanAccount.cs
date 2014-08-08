namespace Bank
{
    using System;

    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(uint numberOfMonths)
        {
            if ((numberOfMonths <= 3 && this.Customer.Equals(Customer.Individual))
                || (numberOfMonths <= 2 && this.Customer.Equals(Customer.Company)))
            {
                return 0;
            }
            else
            {
                return numberOfMonths * this.InterestRate;
            }
        }
    }
}