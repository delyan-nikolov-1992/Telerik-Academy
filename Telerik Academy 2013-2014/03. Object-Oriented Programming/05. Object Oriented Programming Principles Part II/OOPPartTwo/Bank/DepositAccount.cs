namespace Bank
{
    using System;

    public class DepositAccount : Account, IWithdrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public override void Withdraw(decimal withdraw)
        {
            if (withdraw < 0)
            {
                throw new ArgumentOutOfRangeException("The amount for withdraw must be positive!");
            }

            if (withdraw > this.Balance)
            {
                throw new ArgumentOutOfRangeException("Can not withdraw such an amount. Not enough money in the bank!");
            }

            this.Balance -= withdraw;
        }

        public override decimal CalculateInterest(uint numberOfMonths)
        {
            if (this.Balance > 0 && this.Balance <= 1000)
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