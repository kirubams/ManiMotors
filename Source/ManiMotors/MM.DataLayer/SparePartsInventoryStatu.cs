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
    
    public partial class SparePartsInventoryStatu
    {
        public int SparePartsInventoryStatusID { get; set; }
        public int SparePartsInventoryID { get; set; }
        public int SparePartsInventoryStatusTypeID { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Modifiedby { get; set; }
        public string Remarks { get; set; }
    
        public virtual SparePartsInventoryStatusType SparePartsInventoryStatusType { get; set; }
        public virtual SparePartsInventory SparePartsInventory { get; set; }
    }
}
