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
    
    public partial class VehicleInventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleInventory()
        {
            this.VehicleBookingAllotments = new HashSet<VehicleBookingAllotment>();
            this.VehicleInventoryStatus = new HashSet<VehicleInventoryStatu>();
        }
    
        public int VehicleInventoryID { get; set; }
        public int VehicleInfoID { get; set; }
        public string ChasisNo { get; set; }
        public string EngineNo { get; set; }
        public string Color { get; set; }
        public Nullable<System.DateTime> ManfgDate { get; set; }
        public string ServiceBookNo { get; set; }
        public string KeyNo { get; set; }
        public string BatteryNo { get; set; }
        public string BatteryMake { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Modifiedby { get; set; }
        public Nullable<bool> IsMarginPrice { get; set; }
        public Nullable<bool> Is50PercentMarginPrice { get; set; }
        public Nullable<bool> Is70PercentMarginPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleBookingAllotment> VehicleBookingAllotments { get; set; }
        public virtual VehicleInfo VehicleInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleInventoryStatu> VehicleInventoryStatus { get; set; }
    }
}
