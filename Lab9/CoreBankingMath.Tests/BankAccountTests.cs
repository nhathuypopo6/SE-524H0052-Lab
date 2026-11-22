using System;
using Xunit;
using CoreBankingMath;

namespace CoreBankingMath.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_ValidAmount_IncreasesBalance()
        {
            var account = new BankAccount("ACC-001", "Nguyen Nhat Huy", 1000m);
            account.Deposit(500m);
            Assert.Equal(1500m, account.Balance);
        }

        [Fact]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            var account = new BankAccount("ACC-001", "Nguyen Nhat Huy", 1000m);
            account.Withdraw(300m);
            Assert.Equal(700m, account.Balance);
        }

        [Fact]
        public void Withdraw_ExceedingBalance_ThrowsInvalidOperationException()
        {
            var account = new BankAccount("ACC-001", "Nguyen Nhat Huy", 500m);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(600m));
        }
    }
}
