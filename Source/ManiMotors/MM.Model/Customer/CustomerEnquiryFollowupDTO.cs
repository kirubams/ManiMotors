using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model.Customer
{
    public class CustomerEnquiryFollowupDTO
    {
        public int CustomerEnquiryFollowUpID { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ModelName { get; set; }
        public string CustomerMobileNo { get; set; }
        public int CustomerEnquiryId { get; set; }
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }
        public string Description { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string VehicleColor { get; set; }
        public bool IsExchangeVehicle { get; set; }
        public bool IsTestDrive { get; set; }
        public string SalesExecutive { get; set; }
        public bool IsLatestFollowup { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
