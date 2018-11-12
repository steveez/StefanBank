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

            var thisAccount     = BankRepository.GetAccountById(AccountID);
            var recieverAccount = BankRepository.GetAccountById(recieverAccountID);

            //kollar så att båda konton finns
            if (thisAccount == null ||recieverAccount == null)
            {
                Res.Message = $"Kontonummer {recieverAccountID} hittades ej";
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
                Res.Message = $"Överföring på {cash} kr från konto {thisAccount.AccountID} till konto {recieverAccount.AccountID} lyckades. " +
                    $"Saldo på konto {thisAccount.AccountID}: {thisAccount.Cash} kr. " +
                    $"Saldo på konto {recieverAccount.AccountID}: {recieverAccount.Cash} kr.";
                Res.Success = true;
                return Res;
            }
        }
    }
}
