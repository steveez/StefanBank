using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StefanBank.Models;

namespace StefanBank.Models
{
    public class Customer
    {
        public int CostomerID { get; set; }
        public string Forname { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public List<Account> Account { get; set; }
    }
}
