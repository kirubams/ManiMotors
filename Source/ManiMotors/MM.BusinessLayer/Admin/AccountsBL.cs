using MM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Admin
{
    public class AccountsBL
    {
        public int GetCashInHand()
        {
            int cashInHand = 0;
            using (var entities = new ManiMotorsEntities1())
            {
               int Credits =  entities.CashTransactions.Where(c => c.TransactionType == "CREDIT").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                int Debits = entities.CashTransactions.Where(c => c.TransactionType == "DEBIT").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                cashInHand = Credits - Debits;
            }
            return cashInHand;
        }

        public int GetCashInBank()
        {
            int cashInBank = 0;
            using (var entities = new ManiMotorsEntities1())
            {
                int Credits = entities.BankAccountTransactions.Where(c => c.TransactionType == "CREDIT").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                int Debits = entities.BankAccountTransactions.Where(c => c.TransactionType == "DEBIT").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                cashInBank = Credits - Debits;
            }
            return cashInBank;
        }
    }
}
