//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MM.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class BankAccountTransaction
    {
        public int BankAccountTransactionID { get; set; }
        public int BankAccountTypeID { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Modifiedby { get; set; }
        public System.DateTime TransactionDate { get; set; }
    
        public virtual BankAccountType BankAccountType { get; set; }
    }
}
