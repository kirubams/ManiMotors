using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Vehicle
{
    public class FinanceAllotmentDTO
    {
        public int VehicleBookingFinanceAllotmentID { get; set; }
        public int VehicleBookingId { get; set; }
        public int FinancierID { get; set; }
        public string FinancierName { get; set; }
        public DateTime? FinanceDate { get; set; }
        public int? FinanceAmount { get; set; }
        public int? LoanNumber { get; set; }
        public string OtherChargesDescription { get; set; }
        public int? OtherAmount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
