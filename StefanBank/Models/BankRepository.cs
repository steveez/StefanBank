using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StefanBank.Models;

namespace StefanBank.Models
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; }

        public BankRepository()
        {
            Customers = new List<Customer>();
            AddCustomers();
        }
        public BankRepository AddCustomers()
        {
            this.Customers.Add(new Customer()
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
            this.Customers.Add(new Customer()
            {
                CostomerID = 1,
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
            this.Customers.Add(new Customer()
            {
                CostomerID = 1,
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
    }

}
