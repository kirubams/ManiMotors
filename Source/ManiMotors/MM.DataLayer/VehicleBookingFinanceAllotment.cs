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
    
    public partial class VehicleBookingFinanceAllotment
    {
        public int VehicleBookingFinanceAllotmentID { get; set; }
        public int VehicleBookingID { get; set; }
        public int FinancierID { get; set; }
        public Nullable<int> LoanNo { get; set; }
        public Nullable<System.DateTime> FinanceDate { get; set; }
        public Nullable<int> FinanceAmount { get; set; }
        public string OtherChargesDesc { get; set; }
        public Nullable<int> OtherAmount { get; set; }
        public int Createdby { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Modifiedby { get; set; }
    
        public virtual FinanceInfo FinanceInfo { get; set; }
        public virtual VehicleBooking VehicleBooking { get; set; }
    }
}
