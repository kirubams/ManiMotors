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
    
    public partial class ExpenseTransaction
    {
        public int ExpenseTransactionID { get; set; }
        public Nullable<int> ExpenseID { get; set; }
        public string Comments { get; set; }
        public Nullable<int> Amount { get; set; }
        public string DebitType { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Modifiedby { get; set; }
    
        public virtual Expens Expens { get; set; }
    }
}
