using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using StefanBank.Models;

namespace StefanBank.ViewModels
{
    public class TransferViewModel
    {
        [DisplayName("From Account number")]
        public int FromAccountId { get; set; }
        [DisplayName("To Account number")]
        public int ToAccountId { get; set; }
        [DisplayName("Amount")]
        public int Amount { get; set; }

        public ResponseClass ResponseClass { get; set; } = new ResponseClass();

        public string Message { get; set; }
    }
}
