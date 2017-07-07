using MM.DataLayer;
using MM.Model.Admin;
using MM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Admin
{
    public class ExpensesBL
    {
        public List<ExpensesDTO> GetExpenses()
        {
            var lstExpenses = new List<ExpensesDTO>();
            using (var entities = new ManiMotorsEntities1())
            {
                foreach (var ent in entities.Expenses)
                {
                    var expenseDTO = new ExpensesDTO();
                    expenseDTO.ExpenseID = ent.ExpenseID;
                    expenseDTO.Description = ent.Description;
                    lstExpenses.Add(expenseDTO);
                }
            }

            return lstExpenses;
        }

        public bool AddExpenses(ExpensesDTO expensesDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var expense = new Expens()
                    {
                        Description = expensesDTO.Description,
                        CreatedDate = expensesDTO.CreatedDate,
                        Createdby = expensesDTO.CreatedBy,
                        Modifiedby = expensesDTO.ModifiedBy,
                        ModifiedDate = expensesDTO.ModifiedDate
                    };
                    entities.Expenses.Add(expense);
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

        public bool DeleteExpenses(int expenseID)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    entities.Expenses.Remove(entities.Expenses.Where(g => g.ExpenseID == expenseID).FirstOrDefault());
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }

        public bool UpdateExpenses(ExpensesDTO expensesDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var Gamesys = entities.Expenses.Where(g => g.ExpenseID == expensesDTO.ExpenseID).FirstOrDefault();
                    Gamesys.Description = expensesDTO.Description;
                    //Gamesys.CreatedDate = expensesDTO.CreatedDate;
                    //Gamesys.Createdby = expensesDTO.CreatedBy;
                    Gamesys.Modifiedby = expensesDTO.ModifiedBy;
                    Gamesys.ModifiedDate = expensesDTO.ModifiedDate;
                    entities.SaveChanges();
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
