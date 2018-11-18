using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StefanBank.Models;
using StefanBank.ViewModels;

namespace StefanBank.Controllers
{
    public class TransferController : Controller
    {
        public BankRepository _bankRepository { get; set; }
        public TransferController()
        {
            if (_bankRepository == null)
            {
                _bankRepository = new BankRepository();

            }

        }


        public IActionResult Index()
        {
            return View(new TransferViewModel());
        }

        [HttpPost]
        public IActionResult Index(int FromAccountId, int ToAccountId, int Amount)
        {
            TransferViewModel vm = new TransferViewModel();

            var fromAccount  = BankRepository.GetAccountById(FromAccountId);

            if (fromAccount != null)
            {
                vm.ResponseClass = fromAccount.TransferFromThis(ToAccountId, Amount);
                if (vm.ResponseClass.Success)
                {
                    ModelState.Clear();
                }
            }
            else
            {
                vm.ResponseClass.Message = $"Kontonummer {FromAccountId} hittades ej";
            }


            return View(vm);
        }
    }
}