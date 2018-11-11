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
    }
}
