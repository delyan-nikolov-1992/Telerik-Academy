namespace Bank
{
    using System;

    public abstract class Account : IDepositable
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }

        public void Deposit(decimal deposit)
        {
            if (deposit < 0)
            {
                throw new ArgumentOutOfRangeException("The amount for deposit must be positive!");
            }

            this.Balance += deposit;
        }

        public virtual void Withdraw(decimal withdraw)
        {

        }

        public abstract decimal CalculateInterest(uint numberOfMonths);

        public override string ToString()
        {
            return string.Format("Customer: {0}\nBalance: {1}\nInterest rate: {2}\n", this.customer, this.balance, this.interestRate);
        }
    }
}