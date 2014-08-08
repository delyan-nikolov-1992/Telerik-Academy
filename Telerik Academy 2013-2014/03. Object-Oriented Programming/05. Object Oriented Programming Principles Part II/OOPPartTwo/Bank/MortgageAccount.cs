namespace Bank
{
    using System;

    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(uint numberOfMonths)
        {
            if (numberOfMonths <= 12 && this.Customer.Equals(Customer.Company))
            {
                return numberOfMonths * this.InterestRate / 2;
            }
            else if (numberOfMonths <= 6 && this.Customer.Equals(Customer.Individual))
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