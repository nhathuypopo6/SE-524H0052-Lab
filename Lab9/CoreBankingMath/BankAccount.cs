using System;

namespace CoreBankingMath
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public string OwnerName { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, string ownerName, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");
            Balance -= amount;
        }
    }
}
