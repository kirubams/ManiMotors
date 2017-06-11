using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Vehicle
{
    public class VehicleInfoDTO
    {
        public int VehicleInfoID { get; set; }
        public int VehicleTypeID { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public int ExShowRoomPrice { get; set; }
        public int LT_RT_OtherExp { get; set; }
        public int InsurancePrice { get; set; }
        public int OnRoadPrice { get; set; }
        public int MarginPrice { get; set; }
        public int Margin50 { get; set; }
        public int Margin70 { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
