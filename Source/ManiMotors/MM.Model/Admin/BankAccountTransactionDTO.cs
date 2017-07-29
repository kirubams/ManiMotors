using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Admin
{
    public class BankAccountTransactionDTO
    {
        public int BankAccountTransactionID { get; set; }
        public int BankAccountTypeID { get; set; }
        public string BankAccountTypeDescription { get; set; }
        public string TransactionType { get; set; }
        public string Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
