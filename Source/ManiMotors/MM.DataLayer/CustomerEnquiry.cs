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
    
    public partial class CustomerEnquiry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerEnquiry()
        {
            this.CustomerEnquiryFollowUps = new HashSet<CustomerEnquiryFollowUp>();
        }
    
        public int CustomerEnquiryID { get; set; }
        public int CustomerID { get; set; }
        public string ReferenceBy { get; set; }
        public string CashORFinance { get; set; }
        public int SalesExecutive { get; set; }
        public int Model1 { get; set; }
        public Nullable<int> Model2 { get; set; }
        public Nullable<int> Model3 { get; set; }
        public string Color { get; set; }
        public bool TestDrive { get; set; }
        public bool ExchangeVehicle { get; set; }
        public string CompetitiveModel { get; set; }
        public int VehicleStatusID { get; set; }
        public int Createdby { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Modifiedby { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerEnquiryFollowUp> CustomerEnquiryFollowUps { get; set; }
    }
}
