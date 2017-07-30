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
        public int GetCashInHandForSales()
        {
            int cashInHand = 0;
            using (var entities = new ManiMotorsEntities1())
            {
               int Credits =  entities.CashTransactions.Where(c => c.TransactionType == "CREDIT" && c.Type.ToUpper() == "SALES").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                int Debits = entities.CashTransactions.Where(c => c.TransactionType == "DEBIT" && c.Type.ToUpper() == "SALES").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                cashInHand = Credits - Debits;
            }
            return cashInHand;
        }


        public int GetCashInHandForService()
        {
            int cashInHand = 0;
            using (var entities = new ManiMotorsEntities1())
            {
                int Credits = entities.CashTransactions.Where(c => c.TransactionType == "CREDIT" && c.Type.ToUpper() == "SERVICE").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                int Debits = entities.CashTransactions.Where(c => c.TransactionType == "DEBIT" && c.Type.ToUpper() == "SERVICE").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                cashInHand = Credits - Debits;
            }
            return cashInHand;
        }

        public int GetCashInBankForSales()
        {
            int cashInBankSales = 0;
            using (var entities = new ManiMotorsEntities1())
            {
                int Credits = entities.BankAccountTransactions.Where(c => c.TransactionType == "CREDIT" && c.Type.ToUpper() == "SALES").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                int Debits = entities.BankAccountTransactions.Where(c => c.TransactionType == "DEBIT" && c.Type.ToUpper() == "SALES").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                cashInBankSales = Credits - Debits;
            }
            return cashInBankSales;
        }

        public int GetCashInBankForService()
        {
            int cashInBankService = 0;
            using (var entities = new ManiMotorsEntities1())
            {
                int Credits = entities.BankAccountTransactions.Where(c => c.TransactionType == "CREDIT" && c.Type.ToUpper() == "SERVICE").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                int Debits = entities.BankAccountTransactions.Where(c => c.TransactionType == "DEBIT" && c.Type.ToUpper() == "SERVICE").Select(x => x.Amount).DefaultIfEmpty(0).Sum();
                cashInBankService = Credits - Debits;
            }
            return cashInBankService;
        }
    }
}
