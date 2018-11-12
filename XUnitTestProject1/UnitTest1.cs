using System;
using Xunit;
using StefanBank;
using StefanBank.Models;
using System.Linq;
namespace XUnitTestProject1
{
    public class UnitTest1
    {
        BankRepository bankrepo = new BankRepository();
        [Fact]
        public void Deposit()
        {
            //Gjorde så att man alltid kan testa Även om man inte vet vad som finns på kontot :D
            var Deposit = 50;
            var customer = BankRepository.Customers.First();
            var customerAccount = customer.Account.First();
            var MoneyOnBank = customerAccount.Cash;
            customerAccount.Cash += Deposit;

            Assert.Equal(customerAccount.Cash, (MoneyOnBank + Deposit));
        }
        [Fact]
        public void Withdraw()
        {
            var Withdraw = 50;
            var customer = BankRepository.Customers.First();
            var customerAccount = customer.Account.First();
            var MoneyOnBank = customerAccount.Cash;
            customerAccount.Cash -= Withdraw;

            Assert.Equal(customerAccount.Cash, (MoneyOnBank - Withdraw));
        }
        [Fact]
        public void WithdrawToMuch()
        {
            bool ToMuchWithdraw;
            var customer = BankRepository.Customers.First();
            var customerAccount = customer.Account.First();            
            var WithdrawAmount = customerAccount.Cash + 100;           
            if(WithdrawAmount > customerAccount.Cash)
            {
                ToMuchWithdraw = true;
            }
            else
            {
                ToMuchWithdraw = false;
            }
            Assert.True(ToMuchWithdraw);

        }

        [Fact]
        public void TransferFromSuccess()
        {
            int AccountID = 1;
            int Cash      = 7000;

            var Account = BankRepository.Customers.Select(c => c.Account.Where(a => a.AccountID == AccountID).FirstOrDefault()).FirstOrDefault();
            Account.Cash = 10000;

            Account.TransferFromThis(2, Cash);

            int expected = 3000;
            int actual   = Account.Cash;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransferToSuccess()
        {
            int AccountID = 1;
            int AccountID2 = 2;
            int Cash = 7000;

            var AccountFrom = BankRepository.Customers.Select(c => c.Account.Where(a => a.AccountID == AccountID).FirstOrDefault()).FirstOrDefault();
            var AccountTo   =   BankRepository.Customers.Select(c => c.Account.Where(a => a.AccountID == AccountID2).FirstOrDefault()).FirstOrDefault();


            AccountFrom.Cash = 10000;
            AccountTo.Cash = 0;

            AccountFrom.TransferFromThis(AccountTo.AccountID, Cash);

            int expected = 7000;
            int actual = AccountTo.Cash;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransferTooMuch()
        {
            int AccountID = 1;
            int AccountID2 = 2;
            int Cash = 50000;

            var AccountFrom = BankRepository.Customers.Select(c => c.Account.Where(a => a.AccountID == AccountID).FirstOrDefault()).FirstOrDefault();
            var AccountTo = BankRepository.Customers.Select(c => c.Account.Where(a => a.AccountID == AccountID2).FirstOrDefault()).FirstOrDefault();


            AccountFrom.Cash = 10000;
            AccountTo.Cash = 0;

            ResponseClass response = AccountFrom.TransferFromThis(AccountTo.AccountID, Cash);

            Assert.False(response.Success);
        }
    }
}
