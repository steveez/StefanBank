using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StefanBank.Models;
using StefanBank.ViewModels;

namespace StefanBank.Controllers
{
    public class BankController : Controller
    {
        public BankRepository _bankRepository { get; set; }
        public BankController()
        {
            if (_bankRepository == null)
            {
                _bankRepository = new BankRepository();
             
            }
           
        }

    public IActionResult Index()
        {
            var vm = new BankActionModel();
            vm.Message = "";
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(string button, int accountId, int amount)
        {
           
            var vm = new BankActionModel();

           
            var customer =   BankRepository.Customers.FirstOrDefault(c => c.Account.Select(a => a.AccountID == accountId).First());
        

            if (customer != null)
            {

                var balance = customer.Account.FirstOrDefault(a => a.AccountID == accountId).Cash;

                if (button == "Withdraw")
                {
                    if (amount > balance)
                    {
                        vm.Message = "Du försöker ta ut mer än du har !";
                        return View(vm);
                    }

                    _bankRepository.Withdraw(amount, accountId);

                    vm.Message = "Du lyckades ta ut " +amount+" Du har " + customer.Account.FirstOrDefault(a => a.AccountID == accountId).Cash;

                }
                else if (button == "Deposit")
                {

                    _bankRepository.Deposit(amount, accountId);
                    vm.Message = "Du satte in " + amount + " Du har : " + customer.Account.FirstOrDefault(a => a.AccountID == accountId).Cash;
                }
            }
            else
            {
                vm.Message = "Fel konto nummer!";
            }


            return View(vm);
        }

        
    }
}
