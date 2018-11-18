using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StefanBank.Models;
using System.Linq;

namespace StefanBank.Models
{
    public class BankRepository
    {
        public static List<Customer> Customers { get; set; }

        public BankRepository()
        {
            if (Customers == null)
            {
                Customers = new List<Customer>();
                AddCustomers();
            }
          
        }
        private BankRepository AddCustomers()
        {
            Customers.Add(new Customer()
            {
                CostomerID = 1,
                Forname = "Stefan",
                Surname = "Kempe",
                Adress = "Någon adress",
                Account = new List<Account>
            {
                new Account()
                {
                    AccountID = 1,
                    Cash = 10000
                },
                new Account()
                {
                     AccountID = 2,
                    Cash = 10000
                }
            }
            });
           Customers.Add(new Customer()
            {
                CostomerID = 2,
                Forname = "Test",
                Surname = "Efternamn",
                Adress = "Någon adress",
                Account = new List<Account>
            {
                new Account()
                {
                    AccountID = 3,
                    Cash = 5
                },
                new Account()
                {
                     AccountID = 4,
                    Cash = 100
                }
            }
            });
           Customers.Add(new Customer()
            {
                CostomerID = 3,
                Forname = "Micke",
                Surname = "Andersson",
                Adress = "Någon adress",
                Account = new List<Account>
            {
                new Account()
                {
                    AccountID = 5,
                    Cash = 150
                },
                new Account()
                {
                     AccountID = 6,
                    Cash = 300
                }
            }
            });


            return this;

        }
        public void Withdraw(int Amount, int AccountID)
        {
            Customers.FirstOrDefault(c => c.Account.Select(a => a.AccountID == AccountID).First()).Account.FirstOrDefault(a => a.AccountID == AccountID).Cash -= Amount;
        }
        public void Deposit(int Amount, int AccountID)
        {
            Customers.FirstOrDefault(c => c.Account.Select(a => a.AccountID == AccountID).First()).Account.FirstOrDefault(a => a.AccountID == AccountID).Cash += Amount;

        }

        public static Account GetAccountById(int AccountId)
        {
            Account account = null;

            var customer = Customers.Where(c => c.Account.Any(a => a.AccountID == AccountId)).FirstOrDefault();

            if(customer != null)
            {
                account = customer.Account.Where(a => a.AccountID == AccountId).FirstOrDefault();
            }

            return account;
        }
    }

}
