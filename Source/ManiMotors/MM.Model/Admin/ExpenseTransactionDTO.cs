using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Admin
{
    public class ExpenseTransactionDTO
    {
        public int ExpenseTransactionID { get; set; }
        public int? ExpenseID { get; set; }
        public string ExpenseDescription { get; set; }
        public string Comments { get; set; }
        public int Amount { get; set; }
        public string DebitType { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

    }
}
