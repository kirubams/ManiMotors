using MM.DataLayer;
using MM.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Admin
{
    public class ExpenseTransactionBL
    {
        public List<ExpenseTransactionDTO> GetExpenseTransaction()
        {
            var lstExpenseTransaction = new List<ExpenseTransactionDTO>();
            using (var entities = new ManiMotorsEntities1())
            {
                foreach (var ent in entities.ExpenseTransactions)
                {
                    var expenseTransactionDTO = new ExpenseTransactionDTO();
                    expenseTransactionDTO.ExpenseTransactionID = ent.ExpenseTransactionID;
                    expenseTransactionDTO.ExpenseID = ent.ExpenseID ?? 0;
                    expenseTransactionDTO.Comments = ent.Comments;
                    expenseTransactionDTO.Amount = ent.Amount ?? 0;
                    expenseTransactionDTO.DebitType = ent.DebitType;
                    lstExpenseTransaction.Add(expenseTransactionDTO);
                }
            }

            return lstExpenseTransaction;
        }

        //public List<ExpenseTransactionDTO> GetExpenseTransaction(DateTime reportDate, string mode)
        //{
        //    var lstExpenseTransaction = new List<ExpenseTransactionDTO>();
        //    using (var entities = new ManiMotorsEntities1())
        //    {
        //        if (mode == "DAILY")
        //        {
        //            var results = entities.GetDailyExpenseTransaction_SP(reportDate);
        //            foreach (var ent in results)
        //            {
        //                var expenseTransactionDTO = new ExpenseTransactionDTO();
        //                expenseTransactionDTO.ExpenseTransactionID = ent.ExpenseTransactionID;
        //                expenseTransactionDTO.ExpenseID = ent.ExpenseID ?? 0;
        //                expenseTransactionDTO.Comments = ent.Comments;
        //                expenseTransactionDTO.Amount = ent.Amount ?? 0;
        //                expenseTransactionDTO.ExpenseDescription = ent.Description;
        //                expenseTransactionDTO.CreatedDate = ent.CreatedDate ?? DateTime.Now;
        //                lstExpenseTransaction.Add(expenseTransactionDTO);
        //            }
        //        }
        //        else if (mode == "MONTHLY")
        //        {
        //            var results = entities.GetMonthlyExpenseTransaction_SP(reportDate);
        //            foreach (var ent in results)
        //            {
        //                var expenseTransactionDTO = new ExpenseTransactionDTO();
        //                expenseTransactionDTO.ExpenseTransactionID = ent.ExpenseTransactionID;
        //                expenseTransactionDTO.ExpenseID = ent.ExpenseID ?? 0;
        //                expenseTransactionDTO.Comments = ent.Comments;
        //                expenseTransactionDTO.Amount = ent.Amount ?? 0;
        //                expenseTransactionDTO.ExpenseDescription = ent.Description;
        //                expenseTransactionDTO.CreatedDate = ent.CreatedDate ?? DateTime.Now;
        //                lstExpenseTransaction.Add(expenseTransactionDTO);
        //            }

        //        }
        //        else if (mode == "YEARLY")
        //        {
        //            var results = entities.GetYearlyExpenseTransaction_SP(reportDate);
        //            foreach (var ent in results)
        //            {
        //                var expenseTransactionDTO = new ExpenseTransactionDTO();
        //                expenseTransactionDTO.ExpenseTransactionID = ent.ExpenseTransactionID;
        //                expenseTransactionDTO.ExpenseID = ent.ExpenseID ?? 0;
        //                expenseTransactionDTO.Comments = ent.Comments;
        //                expenseTransactionDTO.Amount = ent.Amount ?? 0;
        //                expenseTransactionDTO.ExpenseDescription = ent.Description;
        //                expenseTransactionDTO.CreatedDate = ent.CreatedDate ?? DateTime.Now;
        //                lstExpenseTransaction.Add(expenseTransactionDTO);
        //            }

        //        }
        //    }

        //    return lstExpenseTransaction;
        //}

        public bool AddExpenseTransaction(ExpenseTransactionDTO expenseTransactionDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var expenseTransaction = new ExpenseTransaction()
                    {
                        ExpenseID = expenseTransactionDTO.ExpenseID,
                        Comments = expenseTransactionDTO.Comments,
                        Amount = expenseTransactionDTO.Amount,
                        DebitType = expenseTransactionDTO.DebitType,
                        CreatedDate = expenseTransactionDTO.CreatedDate,
                        Createdby = expenseTransactionDTO.CreatedBy,
                        Modifiedby = expenseTransactionDTO.ModifiedBy,
                        ModifiedDate = expenseTransactionDTO.ModifiedDate
                    };
                    entities.ExpenseTransactions.Add(expenseTransaction);
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }

        public bool UpdateExpenseTransaction(ExpenseTransactionDTO expenseTransactionDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var expenseTran = entities.ExpenseTransactions.FirstOrDefault(g => g.ExpenseTransactionID == expenseTransactionDTO.ExpenseTransactionID);

                    expenseTran.ExpenseTransactionID = expenseTransactionDTO.ExpenseTransactionID;
                    expenseTran.Comments = expenseTransactionDTO.Comments;
                    expenseTran.Amount = expenseTransactionDTO.Amount;
                    expenseTran.DebitType = expenseTransactionDTO.DebitType;
                    expenseTran.Modifiedby = expenseTransactionDTO.ModifiedBy;
                    expenseTran.ModifiedDate = expenseTransactionDTO.ModifiedDate;
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }

        public bool DeleteExpenseTransaction(int expenseTransactionID)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var expenseTran = entities.ExpenseTransactions.FirstOrDefault(g => g.ExpenseTransactionID == expenseTransactionID);

                    entities.ExpenseTransactions.Remove(expenseTran);
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }
    }
}
