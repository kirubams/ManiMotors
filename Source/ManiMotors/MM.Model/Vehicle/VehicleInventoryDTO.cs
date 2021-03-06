﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Vehicle
{
    public class VehicleInventoryDTO
    {
        public int VehicleInventoryID { get; set; }
        public int VehicleInfoID { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelCode { get; set; }
        public string ChasisNo { get; set; }
        public string EngineNo { get; set; }
        public string Color { get; set; }
        public DateTime MfgDate { get; set; }
        public string ServiceBookNo { get; set; }
        public string KeyNo { get; set; }
        public string BatteryNo { get; set; }
        public string BatteryMake { get; set; }
        public int VehicleInventoryStatusTypeID { get; set; }
        public string VehicleInventoryStatusName { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsMarginPrice { get; set; }
        public bool Is50PerMarginPrice { get; set; }
        public bool Is70PerMarginPrice { get; set; }
        public int ExShowRoomPrice { get; set; }
        public int LT_RT_OtherExp { get; set; }
        public int InsurancePrice { get; set; }
        public int OnRoadPrice { get; set; }
        public int MarginPrice { get; set; }
        public int Margin50 { get; set; }
        public int Margin70 { get; set; }
        public int WarrantyPrice { get; set; }
    }
}
