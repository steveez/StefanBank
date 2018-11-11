using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StefanBank.Models;

namespace StefanBank.Controllers
{
    public class HomeController : Controller
    {
       

        public BankRepository bankRepository { get; set; }

       
        public IActionResult Index()
        {

            int MUPP = 100000;
            bankRepository = new BankRepository();
             //BankRepository test = bankRepository.AddCustomers();
            
            return View(bankRepository);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description pageasd.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
