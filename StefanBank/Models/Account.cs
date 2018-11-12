using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StefanBank.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int Cash { get; set; }

        public ResponseClass TransferFromThis (int recieverAccountID, int cash)
        {
            ResponseClass  Res  = new ResponseClass();
            BankRepository bank = new BankRepository();

            var thisAccount     = BankRepository.Customers.Select(c => c.Account.Where(a => a.AccountID == AccountID).FirstOrDefault()).FirstOrDefault();
            var recieverAccount = BankRepository.Customers.Select(c => c.Account.Where(a => a.AccountID == recieverAccountID).FirstOrDefault()).FirstOrDefault();

            //kollar så att båda konton finns
            if(thisAccount == null ||recieverAccount == null)
            {
                Res.Message = "Felaktigt kontonummer";
                return Res;
            }

            //kollar så att tillräckligt med cash finns på konton.
            if (thisAccount.Cash < cash)
            {
                Res.Message = "För lite pengar på kontot";
                return Res;
            }
            else
            {
                thisAccount.Cash     -= cash;
                recieverAccount.Cash += cash;
                Res.Message = $"Överföring på {cash}kr från konto {thisAccount} till {recieverAccount} lyckades";
                Res.Success = true;
                return Res;
            }



        }
    }
}
