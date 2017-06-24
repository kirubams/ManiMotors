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
        public int CustomerEnquiryId { get; set; }
        public string Description { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
