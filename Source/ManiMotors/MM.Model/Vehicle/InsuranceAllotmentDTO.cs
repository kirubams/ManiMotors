using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Vehicle
{
    public class InsuranceAllotmentDTO
    {
        public int VehicleBookingInsuranceAllotmentID { get; set; }
        public int VehicleBookingId { get; set; }
        public bool InsuranceByDealer { get; set; }
        public int InsuranceInfoID { get; set; }
        public string InsuranceName { get; set; }
        public int? CoverNoteNo { get; set; }
        public string PolicyNumber { get; set; }
        public int? PolicyAmount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? PolicyDeliveredDate { get; set; }
        public string ContactNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
