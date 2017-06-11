using System;
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
        public string ChasisNo { get; set; }
        public string EngineNo { get; set; }
        public string Color { get; set; }
        public DateTime MfgDate { get; set; }
        public string ServiceBookNo { get; set; }
        public string KeyNo { get; set; }
        public string BatteryNo { get; set; }
        public string BatteryMake { get; set; }
        public int VehicleInventoryStatusID { get; set; }
        public string VehicleInventoryStatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
