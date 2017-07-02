using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Vehicle
{
    public class VehicleBookingDTO
    {
        public int VehicleBookingID { get; set; }
        public int? VehicleEnquiryID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? CommittedDate { get; set; }
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string CustomerRemark { get; set; }
        public string ReferenceBy { get; set; }
        public string SalesExecutiveName { get; set; }
        public int SalesExecutiveId { get; set; }
        public bool IsCash { get; set; }
        public int? AdvanceAmount { get; set; }
        public bool AdvanceMode { get; set; }
        public int? AdvanceChequeNo { get; set; }
        public int? FinancierInfoId { get; set; }
        public string FinancierName { get; set; }
        public string FinancierRemark { get; set; }
        public bool? ReadyToDeliver { get; set; }
        public int? StatusId { get; set; }
        public string StatusDescription { get; set; }
        public string ClosingRemark { get; set; }
        public string FollowupDescription { get; set; }
        public DateTime FollowupDate { get; set; }
        public bool FollowupIsActive { get; set; }
        public int? VehicleBookingAllotmentId { get; set; }
        public int? FinanceAllotmentId { get; set; }
        public int? InsuranceAllotmentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
