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


        private BankRepository bankRepository;



        public IActionResult Index()
        {

            if(bankRepository == null)
            {
                bankRepository = new BankRepository();
              
            }


            return View(BankRepository.Customers);
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
