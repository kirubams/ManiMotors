using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Vehicle
{
    public class RTOAllotmentDTO
    {
        public int VehicleBookingRTOAllotmentID { get; set; }
        public int VehicleBookingId { get; set; }
        public int RTOInfoID { get; set; }
        public string RTOName { get; set; }
        public string TempRegNo { get; set; }
        public string RegNo { get; set; }
        public DateTime? RegDate { get; set; }
        public int? Amount { get; set; }
        public string AgentName { get; set; }
        public string RCBookNo { get; set; }
        public DateTime? RCDeliveredDate { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
