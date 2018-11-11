using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StefanBank.ViewModels
{
    public class BankActionModel
    {
        [DisplayName("Accountnumber")]
        public int AccountId { get; set; }
        [DisplayName("Amount")]
        public int Amount { get; set; }

        public string Message { get; set; }
    }
}
